using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Unit : MonoBehaviour
{
	public bool isEnemy;
	public UnitFaction unitFaction;
	public List<Unit> connected;

	public Dictionary<Unit, Transform> bridgesByUnits = new Dictionary<Unit, Transform>();

	public HeatComponent Heat
	{
		get;
		set;
	}

	public ClassComponent Class
	{
		get;
		set;
	}

	public MoveComponent Move
	{
		get;
		set;
	}

	public VFXComponent VFX
	{
		get;
		set;
	}

	private void Start()
	{
		GameController.units.Add(this);

		Heat = GetComponent<HeatComponent>();
		Class = GetComponent<ClassComponent>();
		Move = GetComponent<MoveComponent>();
		VFX = GetComponent<VFXComponent>();
		//unitFaction = UnitFactionMethods.TagToFaction(tag);
		isEnemy = unitFaction == UnitFaction.Blue;
	}

	private void Update()
	{
		CheckForLose();
	}

	public bool IsEnemyFactionOf(Unit targetUnit)
	{
		return unitFaction != targetUnit.unitFaction;
	}

	public bool IsAllyFactionOf(Unit targetUnit)
	{
		return unitFaction == targetUnit.unitFaction;
	}

	public bool IsWhite()
	{
		return unitFaction == UnitFaction.Red;
	}

	public bool IsBlack()
	{
		return unitFaction == UnitFaction.Blue;
	}

	private void FixedUpdate()
	{
		Move.Move();
	}

	public void BreakConnectionWith(Unit breakWith)
	{
		GameObject goToDelete = bridgesByUnits[breakWith].gameObject;
		bridgesByUnits.Remove(breakWith);
		goToDelete.GetComponent<FlowBridge>().Suicide();
	}

	void CheckForLose()
	{
		return;
		bool isRedTooHot = Heat.CurrentUnitTemperature < HeatTransferManager.MaximumUnitTemperature *
			(.5f + HeatTransferManager.ThresholdDelta) && IsWhite();
		bool isBlueTooHot = Heat.CurrentUnitTemperature > HeatTransferManager.MaximumUnitTemperature *
			(.5f - HeatTransferManager.ThresholdDelta) && IsBlack();

		if(isRedTooHot || isBlueTooHot)
		{
			Destroy(gameObject);
		}
	}
}
