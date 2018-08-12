using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class FlowBridge : MonoBehaviour
{
	Curve curve;
	LineRenderer line;
	Vector3[] orderPoints = new Vector3[4];
	int pointsN = 100;

	Unit attacker;
	Unit target;

	bool isSetAndEnabled;

	float tLoad = .01f;
	float tUnload = 0f;
	float tShuffle = 0;
	float periodShuffle = 5;
	Vector3[] lastOrderPoints = new Vector3[4];
	Vector3[] nextOrderPoints = new Vector3[4];

	bool isFullInterpolation = false;
	bool isDeadMode = false;

	private void Update()
	{
		if(!target || !attacker)
		{
			isDeadMode = true;
		}

		if(isFullInterpolation && tUnload == 1)
		{
			Destroy(gameObject);
		}

		if(isSetAndEnabled)
		{
			TickTime();
			Interpolate();
		}
	}

	public void SetAndEnable(Unit attacker, Unit target)
	{
		SetValues(attacker, target);
		EnableLine();

		isSetAndEnabled = true;
	}

	public void Suicide()
	{
		isFullInterpolation = true;
	}

	void SetValues(Unit a, Unit b)
	{
		attacker = a;
		target = b;
		curve = new Curve(4, 4, pointsN, 1, new Vector3(1, 1, 1));
		nextOrderPoints = GetUpdatedOrderPoints();
		lastOrderPoints = GetUpdatedOrderPoints();
	}

	void EnableLine()
	{
		line = transform.gameObject.AddComponent<LineRenderer>();
		var curve = new AnimationCurve();
		//curve.AddKey(0, 0);
		//curve.AddKey(.05f, .1f);
		//curve.AddKey(.1f, .3f);
		//curve.AddKey(.9f, .1f);
		//curve.AddKey(1f, .01f);
		//line.widthCurve = curve;
		line.startWidth = .3f;
		line.endWidth = .1f;
		line.positionCount = pointsN;
		line.material = Resources.Load("Line/LineMaterial") as Material;

		Color attackerColor, targetColor;
		ColorMap.GetColorForFight(attacker, target, out attackerColor, out targetColor);
		line.startColor = attackerColor;
		line.endColor = targetColor;
	}

	void TickTime()
	{
		if(isFullInterpolation)
		{
			if(tUnload < 1)
			{
				tUnload += Time.deltaTime*3;

				if(tUnload > 1)
				{
					tUnload = 1;
				}
			}
			else
			{
				tUnload = 1;
			}
		}

		if(tLoad < 1)
		{
			tLoad += Time.deltaTime;

			if(tLoad > 1)
			{
				tLoad = 1;
			}
		}
		else
		{
			tLoad = 1;
		}

		if(!isDeadMode)
		{
			if(tShuffle < 1 && !isFullInterpolation)
			{
				tShuffle += Time.deltaTime / periodShuffle;
			}
			else
			{
				tShuffle = 0;
				CansasCityShuffle();
			}
		}
	}

	void CansasCityShuffle()
	{
		lastOrderPoints = nextOrderPoints;
		nextOrderPoints = GetUpdatedOrderPoints();
	}

	Vector3[] GetUpdatedOrderPoints()
	{
		Vector3[] randomizedOderPoints = new Vector3[4];

		Vector3 att = attacker.VFX.core.position;
		Vector3 trg = target.VFX.core.position;

		randomizedOderPoints[0] = att;
		randomizedOderPoints[3] = trg;

		Vector3 delta = target.VFX.core.position - attacker.VFX.core.position;
		float d = delta.magnitude;
		float y0 = 0, yn = 0, w = 1;
		float d0 = .1f;
		float d1n = .45f;
		float d20 = .55f;
		float dn = .9f;

		if(attacker.Class.unitClass == UnitClass.Tank || target.Class.unitClass == UnitClass.Tank)
		{
			SetConstraints(UnitClass.Tank, d, out y0, out yn, out w);
		}
		else if(attacker.Class.unitClass == UnitClass.Support || target.Class.unitClass == UnitClass.Support)
		{
			SetConstraints(UnitClass.Support, d, out y0, out yn, out w);
		}
		else if(attacker.Class.unitClass == UnitClass.Carry || target.Class.unitClass == UnitClass.Carry)
		{
			SetConstraints(UnitClass.Carry, d, out y0, out yn, out w);
		}

		float rx1 = Random.Range(d0, d1n);
		float rx2 = Random.Range(d20, dn);
		float ry1 = Random.Range(y0, yn);
		float ry2 = Random.Range(y0, yn);
		float rz1 = Random.Range(-w / 2, w / 2);
		float rz2 = Random.Range(-w / 2, w / 2);

		Vector3 localForward = (trg - att).normalized;
		Vector3 localRight = Vector3.Cross(Vector3.up, localForward);
		Vector3 localUp = -Vector3.Cross(localRight, localForward) * att.y;

		Vector3 offset1 = localForward * rx1 * d + localRight * rz1 + localUp * ry1;
		Vector3 offset2 = localForward * rx2 * d + localRight * rz2 + localUp * ry2;

		randomizedOderPoints[1] = offset1 + att;
		randomizedOderPoints[2] = offset2 + att;

		return randomizedOderPoints;
	}

	void SetConstraints(UnitClass unitClass, float d, out float y0, out float yn, out float w)
	{
		if(unitClass == UnitClass.Carry)
		{
			y0 = 0;
			yn = d * .4f;
			w = .5f;

		}
		else if(unitClass == UnitClass.Support)
		{
			y0 = 0f;
			yn = 0f;
			w = 1;
		}
		else
		{
			y0 = -1;
			yn = 0;
			w = .5f;
		}
	}

	void Interpolate()
	{
		if(isDeadMode)
		{
			//empty
		}
		else if(isFullInterpolation)
		{
			orderPoints[0] = attacker.VFX.core.position;
			orderPoints[3] = target.VFX.core.position;
		}
		else
		{
			for(int i = 0; i < lastOrderPoints.Length; i++)
			{
				orderPoints[i] = Vector3.Lerp(lastOrderPoints[i], nextOrderPoints[i], tShuffle);
			}
		}

		curve.RecomputeWithOrderPoints(orderPoints);

		Vector3[] pointsOld = curve.points;
		List<Vector3> points = new List<Vector3>(pointsOld.ToList());

		if(tLoad < 1)
		{
			points = new List<Vector3>();
			Vector3 endOfLine = pointsOld[0];

			if(tLoad < 1)
			{
				for(int i = 0; i < pointsN; i++)
				{
					if(i < pointsN * tLoad)
					{
						points.Add(pointsOld[i]);
					}
				}
			}
		}

		Vector3 startOfLine = pointsOld[pointsOld.Length - 1];

		if(isFullInterpolation)
		{
			if(tUnload <= 1)
			{
				points = new List<Vector3>();

				for(int i = pointsN - 1; i >= 0; i--)
				{
					if(i > pointsN * tUnload)
					{
						points.Insert(0, pointsOld[i]);
					}
				}
			}
		}

		line.positionCount = points.Count;
		line.SetPositions(points.ToArray());
	}
}
