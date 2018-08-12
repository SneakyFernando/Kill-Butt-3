using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class HeatTransferManager
{
	public static float MaximumUnitTemperature = 1000;
	public static float ThresholdDelta = 0f;
	public static float BaseHeatTransferRate = 400;

    public static void TransferHeatBetweenUnits(Unit left, Unit right)
    {
        var leftClass = left.Class;
        var rightClass = right.Class;

        var leftHeat = left.Heat;
        var rightHeat = right.Heat;

        float deltaTemperature = leftHeat.CurrentUnitTemperature - rightHeat.CurrentUnitTemperature;

        bool isAlly = left.IsAllyFactionOf(right);

		if(isAlly)
		{
			if(left.IsBlack() && deltaTemperature > 0)
			{
				//return;
			}

			if(left.IsWhite() && deltaTemperature < 0)
			{
				//return;
			}
		}

        float leftTransferEfficiency = isAlly ? leftHeat.AllyTransferEfficiency : leftHeat.EnemyTransferEfficiency;
        float rightTransferEfficiency = isAlly ? rightHeat.AllyTransferEfficiency : rightHeat.EnemyTransferEfficiency;

        float leftDelta = deltaTemperature / (leftTransferEfficiency * leftHeat.Mass * BaseHeatTransferRate);
        float rightDelta = deltaTemperature / (rightTransferEfficiency * rightHeat.Mass * BaseHeatTransferRate);

        leftDelta = leftClass.Calculate(left, right, leftDelta);
        rightDelta = rightClass.Calculate(left, right, rightDelta);

		leftHeat.ApplyChangeToTemperature(-leftDelta);
		rightHeat.ApplyChangeToTemperature(rightDelta);
    }
}

