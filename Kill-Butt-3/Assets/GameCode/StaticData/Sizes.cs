using UnityEngine;

class Sizes : MonoBehaviour
{
	public class Map
	{
		public static float nodeToNoteDistance = 500;
	}

	public class UI
	{
		public static float pixelsPerUnit = 100;
		public static Vector2 localScale = new Vector2(0.5f, 0.5f);
	}

	public class WallData
	{
		public static float padding = 1f;
		public static float uiJointColliderSizeMultiplier = 2;

		public static Vector2 inputFieldPixelSize
		{
			get
			{
				return UI.pixelsPerUnit * new Vector2(16, 3);
			}
		}

		public static Vector2 contentPixelSize
		{
			get
			{
				return UI.pixelsPerUnit * new Vector2(14, 1.7f);
			}
		}

		public static int fontSize
		{
			get
			{
				return (int)UI.pixelsPerUnit * 2;
			}
		}
	}

	public class Ideas
	{
		public static float sizeMultiplier = 2;
		public static Vector2 sizeNameGUI = new Vector2(1, .5f);
		//public static float HitForceMultiplier = 222f;
		public static float movingHeightOffset = 2;
	}

	public class Physics
	{
		public static float raycastDistance = 10000;
	}

	public class BuildingParameters
	{
		public static float d = .5f;
		public static float heightMiliDelta = 0.001f;
	}
	//think about if we need store size info in each segment 
	//think about if we need to make size info storage for each room
	public class Corridors
	{
		//public static int orderPointsAmount = 4;
		public static int order = 4;
		public static int pointsAmount = 100;
		//public static float maxRadius = 30;
		//public static Vector3 randomizeVector = new Vector3(1,0.2f,1);
		public static Vector2 size = new Vector3(Doors.w, Doors.h);
		public static float windowHeight = Doors.h / 3;
		public static float windowBaseHeight = Doors.h / 3;
		public static float trackHeight = 1;
		public static float lineWidth
		{
			get
			{
				return Doors.h * 2.5f;
			}
		}
		public static float lineEndWidthMultiplier = .5f;
	}

	public class Rooms
	{
		public static float w = 35;
		public static float h = 21;
		public static float l = 35;

		public static Vector3 Size
		{
			get
			{
				return new Vector3(w, h, l);
			}
		}
	}

	public class Walls
	{
		public static float ceilingDelta
		{
			get
			{
				return Rooms.h / 3;
			}
		}
	}

	public class Sides
	{
		public class Sections
		{
			public static float wallMinWidth = Doors.w * 1.5f;
			public static float deltaDeepness
			{
				get
				{
					return wallMinWidth/ 2;
				}
			}
		}
	}
	

	public class Doors
	{
		public static float w = 2;
		public static float h = 4;

		public static float DoorWallWidth
		{
			get
			{
				return w * 29.7f / 21;
			}
		}

		public static Vector2 Size
		{
			get
			{
				return new Vector3(w, h);
			}
		}

		public static float doorOutlineThicness
		{
			get
			{
				return h / 3;
			}
		}
	}
}