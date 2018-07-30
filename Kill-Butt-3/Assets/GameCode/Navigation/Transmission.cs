using System.Collections;
using UnityEngine;

class Transmission
{
	

	public Vector3 _aim;
	public Vector3 Aim
	{
		get
		{
			return _aim;
		}
		set
		{
			_aim = value;
			Engine.MoveToAim(this);
		}
	}
	public bool isMoving;
	public bool aimed;

	public float speed;
	public float acceleration;

	public Transmission(MotionAccess motionAccess)
	{
		unit = motionAccess.unit;
		this.motionAccess = motionAccess;
	}

	public void ProcessDispatcherReport(bool isMassMove)
	{
		MoveInfo moveInfo = Dispatcher.Instance.Report(unit.transform.position);
		Transform what = moveInfo.hittedTransform;
		Vector3 where = moveInfo.hittedPoint;
		bool isUnit = moveInfo.isUnit;

		if(isUnit)
		{
			Target = moveInfo.hittedTransform;
		}
		else
		{
			aimed = false;
			if(isMassMove)
			{
				Aim = NavigationTools.HandleMassMove(unit, moveInfo.hittedPoint);
			}
			else
			{
				Aim = moveInfo.hittedPoint;
			}
		}
	}

	public void Work()
	{
		// remake all coroutins to transmission system
	}
}