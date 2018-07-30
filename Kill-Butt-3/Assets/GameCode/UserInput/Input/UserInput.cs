using UnityEngine;
using CameraRotationSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class UserInput : MonoBehaviour
{
	RaycastHit hit;
	Ray ray;

	private void Update()
	{
		
	}

	private void LateUpdate()
	{
		if(Input.GetButton(KeyBindingsData.EnableCameraRotation))
		{
			CameraBehaviour.ChangeAngle();
		}

		if(Input.GetAxis(KeyBindingsData.zAxis) != 0)
		{
			CameraBehaviour.ChangeDistance();
		}
	}
	
}
