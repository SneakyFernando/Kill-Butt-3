using UnityEngine;
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
		if(Input.GetButton("RMB"))
		{
			CameraBehaviour.ChangeAngle();
		}

		if(Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			CameraBehaviour.ChangeDistance();
		}
	}
	
}
