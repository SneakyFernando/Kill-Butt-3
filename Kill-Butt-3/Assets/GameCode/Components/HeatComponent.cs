using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using UnityEngine;

public class HeatComponent : MonoBehaviour
{
	public Unit unit;

	[SerializeField]
	public int Mass;
	[SerializeField]
	public int AllyTransferEfficiency;
	[SerializeField]
	public int EnemyTransferEfficiency;
	public Thermometer thermometer;
	public float CurrentUnitTemperature;
	//{
	//	get;
	//	private set;
	//}

	private void Start()
	{
		unit = GetComponent<Unit>();

		if(unit.unitFaction == UnitFaction.Blue)
		{
			CurrentUnitTemperature = 0;
		}
		else
		{
			CurrentUnitTemperature = HeatTransferManager.MaximumUnitTemperature;
		}

		//thermometer = new Thermometer(this);
	}

	private void Update()
	{
		//thermometer.Adjust(CurrentUnitTemperature);
	}

	public void ApplyChangeToTemperature(float temperatureChange)
	{
		CurrentUnitTemperature += temperatureChange;
	}
}
