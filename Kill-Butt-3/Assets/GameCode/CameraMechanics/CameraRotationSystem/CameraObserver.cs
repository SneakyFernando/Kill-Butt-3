using UnityEngine;

namespace CameraRotationSystem
{
	public static class Observer
	{
		public static float r;
		public static float phi;
		public static float theta;
		public static Transform core;
		public static Transform freecore;

		public static void SwitchTarget(Transform core)//bon apetite, thats our firm spaghetti, dont choke
		{
			if(Observer.core != null)
			{
				//Observer.core.localScale = SphericalCoordinates.HeilSphericalCoordinateSystem(theta, phi, r);
				Observer.core.localScale = new Vector3(theta, phi, r);
			}

			Observer.core = core;

			if(core == freecore)
			{
				r = freecore.localScale.z;
				return;
			}

			Vector3 data = Vector3.zero;


			if(Interface.transform.position == Vector3.zero)
			{
				r = Settings.r0;
				phi = Settings.phi0;
				theta = Settings.theta0;
				Rotator.RefreshTransform();
			}

			if(core.localScale == Vector3.one)
			{
				//data = SphericalCoordinates.SystemCoordinateSphericalHeil(/*Quaternion.Inverse( Interface.transform.rotation)**/( Interface.transform.position-core.position));
				data = new Vector3(Settings.theta0, Settings.phi0, Settings.r0);
			}
			else
			{
				//data = SphericalCoordinates.SystemCoordinateSphericalHeil(core.localScale);
				data = (core.localScale);

			}

			r = data.z;
			theta = data.x;
			phi = data.y;
			//Debug.Log("SWITCHED TO " + core.name + " w r of " + r);

		}


		//public static void Flush()
		//{
		//	r = Settings.rMax;
		//	phi = Settings.phi0;
		//	theta = Settings.theta0;
		//}

		public static void SetFreecore(Vector3 position, Quaternion rotation, float r)
		{
			freecore.Adjust(position, rotation);
			freecore.localScale = new Vector3(1, 1, r);
		}
	}
}