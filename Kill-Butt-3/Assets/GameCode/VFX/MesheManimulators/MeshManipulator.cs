using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshManipulator : MonoBehaviour
{
	protected Unit unit;
	public Transform coreElement;
	public List<HeatSink> sinks;
	public int healthIndicator;

	public static Material redSinkOn;
	public static Material redSinkOff;
	public static Material blueSinkOn;
	public static Material blueSinkOff;

	private void Start()
	{
		unit = transform.parent.GetComponent<Unit>();

		PreSetUp();
		SetUp();
		PostSetUp();
	}

	private void Update()
	{
		Animate();
		HandleTicks();
	}

	protected void PreSetUp()
	{
		transform.position = Vector3.zero;
	}

	protected virtual void SetUp()
	{

	}

	protected void PostSetUp()
	{
		transform.SetParent(unit.transform);
		transform.position = unit.transform.position;

		foreach(var collider in transform.GetComponentsInChildren<Collider>())
		{
			Destroy(collider);
		}
	}

	protected virtual void Animate()
	{

	}

	protected virtual void HandleTicks()
	{

	}

	public void ApplyForHealthChange(float normalValue)
	{
		int newHealthIndicator;

		if(unit.unitFaction == UnitFaction.Red)
		{

			newHealthIndicator = Mathf.CeilToInt(normalValue * sinks.Count);
		}
		else
		{
			newHealthIndicator = Mathf.FloorToInt(normalValue * sinks.Count) + 1;
		}

		if(newHealthIndicator != healthIndicator)
		{
			healthIndicator = newHealthIndicator;
			OnHealthChange();
		}
	}

	protected virtual void OnHealthChange()
	{
		for(int i = 0; i < sinks.Count; i++)
		{
			if(unit.unitFaction == UnitFaction.Red)
			{
				if(i < healthIndicator)
				{
					sinks[sinks.Count-i-1 ].ApplyMaterial(redSinkOn);
				}
				else
				{
					sinks[sinks.Count - i - 1].ApplyMaterial(redSinkOff);
				}
			}
			else
			{
				if(healthIndicator > i)
				{
					sinks[i].ApplyMaterial(blueSinkOn);
				}
				else
				{
					sinks[i].ApplyMaterial(blueSinkOff);
				}
			}
		}
	}
}

