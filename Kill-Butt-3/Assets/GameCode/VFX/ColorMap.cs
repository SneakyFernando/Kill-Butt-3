using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class ColorMap
{
	const string RedCarryColor = "FF0000";
	const string RedSupportColor = "FFFF00";
	const string RedTankColor = "00FF00";
	
	const string BlueCarryColor = "FF00FF";
	const string BlueSupportColor = "0000FF";
	const string BlueTankColor = "00FFFF";

	static Color HexToColor(string hex)
	{
		hex = hex.Replace("0x", "");
		hex = hex.Replace("#", "");
		byte a = 255;
		byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

		if(hex.Length == 8)
		{
			a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
		}

		return new Color32(r, g, b, a);
	}

	public static void GetColorForFight(Unit attacker, Unit target, out Color attackerColor, out Color targetColor)
	{
		if(attacker.unitFaction == UnitFaction.Blue)
		{
			attackerColor = GetForBlack(attacker.Class.unitClass);
		}
		else
		{
			attackerColor = GetForWhite(attacker.Class.unitClass);
		}

		if(target.unitFaction == UnitFaction.Blue)
		{
			targetColor = GetForBlack(target.Class.unitClass);
		}
		else
		{
			targetColor = GetForWhite(target.Class.unitClass);
		}
	}

	static Color GetForWhite(UnitClass unitClass)
	{
		if(unitClass == UnitClass.Carry)
		{
			return HexToColor(RedCarryColor);
		}
		else if(unitClass == UnitClass.Support)
		{
			return HexToColor(RedSupportColor);
		}
		else
		{
			return HexToColor(RedTankColor);
		}
	}

	static Color GetForBlack(UnitClass unitClass)
	{
		if(unitClass == UnitClass.Carry)
		{
			return HexToColor(BlueCarryColor);
		}
		else if(unitClass == UnitClass.Support)
		{
			return HexToColor(BlueSupportColor);
		}
		else
		{
			return HexToColor(BlueTankColor);
		}
	}
}

