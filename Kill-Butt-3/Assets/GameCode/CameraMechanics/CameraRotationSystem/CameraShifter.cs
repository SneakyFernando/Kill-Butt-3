using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace CameraRotationSystem
{
	static class Shifter
	{
		static Transform Core
		{
			get
			{
				return Observer.core;
			}
		}
		static Transform Camera
		{
			get
			{
				return Interface.transform;
			}
		}
		static float t = 0;
		static float a;
		static Vector3 lastPosition;
		static Quaternion lastRotation;

		public static IEnumerator ShiftBetweenRooms(Stack<Transform> ps, Transform destination)
		{
			Transform temp = new GameObject().transform;
			temp.Align(Camera);
			temp.SetParent(Brain.I.transform);
			ps.Push(temp);

			Interface.isInterpolating = true;
			t = 0;
			a = 0;
			//Observer.SwitchTarget(ps.Pop());
			//while(Interpolate())
			//{
			//	yield return new WaitForFixedUpdate();
			//}
			//ps.Push(Core);

			//if((Camera.position - c).sqrMagnitude > (Camera.position - b).sqrMagnitude)
			//{
			//	//ps.Push(b);
			//	//ps.Push(c);
			//	temp = new Stack<Vector3>(team.Reverse());
			//}
			lastPosition = Camera.position;
			lastRotation = Camera.rotation;

			while(MoveAlong(ps))
			{
				//while(MoveAlong(ps)) ;
				yield return new WaitForFixedUpdate();
			}

			Observer.SwitchTarget(destination);
			t = 0;

			while(Interpolate())
			{
				yield return new WaitForFixedUpdate();
			}

			Interface.isInterpolating = false;
			Object.Destroy(temp.gameObject);
			yield return null;
		}

		static bool MoveAlong(Stack<Transform> ps)
		{
			Transform c = ps.Pop();
			Transform b = ps.Peek();
			t += Time.deltaTime * Settings.inCorridorSpeed * a;

			Camera.position = Vector3.Lerp(lastPosition, c.position, t);
			Quaternion destionarionRotation = Quaternion.LookRotation(b.position - c.position, b.up);
			Camera.rotation = Quaternion.Lerp(lastRotation, destionarionRotation, t);

			if(Camera.position == c.position)
			{
				//t = 0;
				a += Time.deltaTime * Settings.inCorridorAcceleration;
				lastPosition = Camera.position;
				lastRotation = Camera.rotation;
			}
			else
			{
				ps.Push(c);
			}

			if(ps.Count == 1)
			{
				return false;
			}

			return true;
		}

		static bool Interpolate()
		{
			t += Time.deltaTime;
			Vector3 endPosition = Core.rotation * SphericalCoordinates.HeilSphericalCoordinateSystem(Observer.theta, Observer.phi, Observer.r) + Core.position;
			Quaternion endRotation = Quaternion.LookRotation(Core.position - endPosition, Core.up);
			Camera.position = Vector3.Lerp(Camera.position, endPosition, t);
			Camera.rotation = Quaternion.Slerp(Camera.rotation, endRotation, t);

			if(endPosition == Camera.position)
			{
				return false;
			}

			return true;
		}
	}
}