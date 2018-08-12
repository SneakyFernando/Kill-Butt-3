using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class UserInput : MonoBehaviour
{
	Unit selectedUnit;
	RaycastHit hit;
	Ray ray;

	private void Update()
	{
		if(Input.GetButtonDown("LMB") || Input.GetButtonUp("LMB"))
		{
			ray = CameraBehaviour.camera.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit, 1000))
			{
				if(hit.transform.tag == "Cell")
				{
					if(Input.GetButtonDown("LMB"))
					{
						MoveComponent occupiedMoveComp = Field.Get(hit.transform.position);

						if(!occupiedMoveComp)
						{
							return;
						}

						Unit hitedUnit = occupiedMoveComp.unit;

						if(selectedUnit != hitedUnit)
						{
							selectedUnit = hitedUnit;
						}
					}
					else if(Input.GetButtonUp("LMB") && selectedUnit!= null)
					{
						selectedUnit.Move.SetAim(hit.transform.position);
						selectedUnit = null;
					}
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
