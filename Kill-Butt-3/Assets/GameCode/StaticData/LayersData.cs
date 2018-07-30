using UnityEngine;

class LayersData
{
	//public static LayerMask IgnoreRaycast
	//{
	//	get
	//	{
	//		return 1 << 3;
	//	}
	//}

	//public static LayerMask Default
	//{
	//	get
	//	{
	//		return LayerMask.NameToLayer("Default");
	//	}
	//}

	public static int Room
	{
		get
		{
			return LayerMask.NameToLayer("Room");
		}
	}

	public static LayerMask RoomMask
	{
		get
		{
			return 1 << Room;
		}
	}
	public static int Side
	{
		get
		{
			return LayerMask.NameToLayer("Side");
		}
	}

	public static LayerMask SideMask
	{
		get
		{
			return 1 << Side;
		}
	}

	public static int Wall
	{
		get
		{
			return LayerMask.NameToLayer("Wall");
		}
	}

	public static LayerMask WallMask
	{
		get
		{
			return 1 << Wall;
		}
	}

	public static LayerMask WallDataMask
	{
		get
		{
			return WallDataGUIMask | TextDataMask;
		}
	}

	public static int TextData
	{
		get
		{
			return LayerMask.NameToLayer("TextData");
		}
	}

	public static LayerMask TextDataMask
	{
		get
		{
			return 1 << TextData;
		}
	}

	public static int WallDataGUI
	{
		get
		{
			return LayerMask.NameToLayer("WallDataGUI");
		}
	}

	public static LayerMask WallDataGUIMask
	{
		get
		{
			return 1 << WallDataGUI;
		}
	}

	public static int Idea
	{
		get
		{
			return LayerMask.NameToLayer("Idea");
		}
	}

	public static LayerMask IdeaMask
	{
		get
		{
			return 1 << Idea;
		}
	}
}

