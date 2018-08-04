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
		if(Input.GetButton("LMB"))
		{
			Ray m = CameraBehaviour.camera.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(m.origin, m.direction , out hit, 1000))
			{
				if(hit.transform.tag == "Cell")
				{
					if(Dispatcher.selectedAlly)
					{
						Dispatcher.selectedAlly.SetAim(hit.transform.position);
					}
				}

				if(hit.transform.tag == "Unit")
				{
					Dispatcher.selectedAlly = hit.transform.GetComponent<Unit>();
				}				
			} 
		}
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
