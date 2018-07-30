namespace CameraRotationSystem
{
	public static class Settings
	{
		public static float phiAxisSpeed = 5;
		public static float thetaAxisSpeed = 5;
		public static float rAxisSpeed = 20;

		public static float thethaMin = 1;
		public static float thethaMax = 179;
		public static float rMin = .5f;
		public static float rMax = 9999;

		public static float hitOffset = .8f;

		public static float r0 = Sizes.Rooms.Size.y / 3;
		public static float phi0 = 90;
		public static float theta0 = 90;

		public static float inCorridorSpeed = 3;
		public static float inCorridorAcceleration = 25;
	}
}