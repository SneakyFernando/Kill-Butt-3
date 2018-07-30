using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CameraRotationSystem
{
	static class Interface
	{
		public static Transform transform;
		public static Camera camera;
		public static bool isInterpolating;

		public static void Switch()
		{
			//camera.orthographic = !camera.orthographic;
			//GlobalDaddy.Instance.map.gameObject.SetActive(!camera.orthographic);

			//if(camera.orthographic)
			//{
			//	transform.position += Vector3.up * 2;
			//}
			//else
			//{
			//	transform.position -= Vector3.up * 2;
			//}
		}
	}
}