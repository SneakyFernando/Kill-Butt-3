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
}

