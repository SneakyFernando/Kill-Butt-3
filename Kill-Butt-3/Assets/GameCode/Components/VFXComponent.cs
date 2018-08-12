using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VFXComponent : MonoBehaviour
{
	public Transform core;
	public MeshManipulator meshManipulator;
	Unit unit;

	private void Start()
	{
		unit = GetComponent<Unit>();
		//core = GetComponentsInChildren<Transform>().Where(t => t.gameObject.name == "Core").FirstOrDefault().transform;
		core = transform;
		GenerateMeshes();
	}

	void GenerateMeshes()
	{
		GameObject meshHolder = new GameObject(unit.tag + " " + UnitClass.Carry.ToString());
		meshHolder.transform.position = Vector3.zero;

		if(unit.Class.unitClass == UnitClass.Carry)
		{

		}
		else if(unit.Class.unitClass == UnitClass.Support)
		{
			meshManipulator =  meshHolder.AddComponent<RadiatorSphere>();
		}
		else if(unit.Class.unitClass == UnitClass.Tank)
		{
			meshManipulator = meshHolder.AddComponent<LockBlock>();
		}

		meshHolder.transform.SetParent(transform);
	}

	private void Update()
	{
		AdjustTemperatureRepresentation();
	}

	public void AdjustTemperatureRepresentation()
	{
		float currentTemperature = unit.Heat.CurrentUnitTemperature;
		float bottomTemperature;
		float topTemperature;

		if(unit.unitFaction == UnitFaction.Red)
		{
			bottomTemperature = HeatTransferManager.MaximumUnitTemperature * (.5f + HeatTransferManager.ThresholdDelta);
			topTemperature = HeatTransferManager.MaximumUnitTemperature;
		}
		else
		{
			bottomTemperature = 0;
			topTemperature = HeatTransferManager.MaximumUnitTemperature * (.5f - HeatTransferManager.ThresholdDelta);
		}

		float normalTemerature = (currentTemperature - bottomTemperature)/ (topTemperature - bottomTemperature);

		meshManipulator.ApplyForHealthChange(normalTemerature);
	}
}

