using UnityEngine;

namespace CameraRotationSystem
{
	static class Rotator
	{
		static Transform Core
		{
			get
			{
				return Observer.core;
			}
		}

		static Transform Transform
		{
			get
			{
				return Interface.transform;
			}
		}

		public static void InputR()
		{
			Observer.r = Mathf.Clamp(Observer.r - Input.GetAxis(KeyBindingsData.zAxis) * Settings.rAxisSpeed * (1 + Observer.r * 0.05f), Settings.rMin, Settings.rMax);
		}

		public static void InputThetaPhi()
		{
			Observer.theta += Input.GetAxis(KeyBindingsData.yAxis) * Settings.thetaAxisSpeed;
			Observer.phi -= Input.GetAxis(KeyBindingsData.xAxis) * Settings.phiAxisSpeed;

			Observer.theta = SphericalCoordinates.ClampTheta(Observer.theta, Settings.thethaMin, Settings.thethaMax);
			Observer.phi = SphericalCoordinates.ClampPhi(Observer.phi);
		}

		public static void RefreshTransform()
		{
			Transform.position = Core.rotation * SphericalCoordinates.HeilSphericalCoordinateSystem(Observer.theta, Observer.phi, Observer.r)+ Core.position;
			//Vector3 dick = SphericalCoordinates.SystemCoordinateSphericalHeil(Transform.position);
			//Transform.position = SphericalCoordinates.HeilSphericalCoordinateSystem(dick.x, dick.y, dick.z);
			//Transform.position += Core.position;


			//RaycastHit hit;

			//if(Physics.Raycast(Core.position, Transform.position - Core.position, out hit, 300, LayersData.SideMask))
			//{
			//	float newR = Mathf.Clamp(hit.distance - Settings.hitOffset, Settings.rMin, Observer.r);
			//	Transform.position = Core.rotation * SphericalCoordinates.HeilSphericalCoordinateSystem(Observer.theta, Observer.phi, newR) + Core.position;
			//	Observer.r = newR;
			//}

			Transform.rotation = Quaternion.LookRotation(Core.position - Transform.position, Core.up);
		}
	}
}