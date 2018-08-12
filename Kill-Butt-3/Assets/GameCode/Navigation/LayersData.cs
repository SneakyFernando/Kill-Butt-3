using UnityEngine;

class LayersData
{
	public static int Unit
	{
		get
		{
			return LayerMask.NameToLayer("Unit");
		}
	}

	public static LayerMask UnitMask
	{
		get
		{
			return 1 << Unit;
		}
	}

	public static int Cell
	{
		get
		{
			return LayerMask.NameToLayer("Cell");
		}
	}

	public static LayerMask CellMask
	{
		get
		{
			return 1 << Cell;
		}
	}
}

