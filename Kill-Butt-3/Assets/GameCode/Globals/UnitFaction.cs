using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum UnitFaction
{
	Red = 0x01,
	Blue = 0x02
}

static class UnitFactionMethods
{
    public const string TagRedFaction = "RedFaction";
    public const string TagBlueFaction = "BlueFaction";

    public static string FactionToTag(UnitFaction unitFaction)
    {
        if(unitFaction == UnitFaction.Red)
        {
            return TagRedFaction;
        }

        return TagBlueFaction;
    }

    public static UnitFaction TagToFaction(string tagUnitFaction)
    {
        if(tagUnitFaction == TagRedFaction)
        {
            return UnitFaction.Red;
        }

        return UnitFaction.Blue;
    }
}
