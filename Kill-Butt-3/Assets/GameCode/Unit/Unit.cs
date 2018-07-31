using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class Unit : MonoBehaviour
{
	public bool isMoving;

	protected List<Stack<Vector3>> moveSet;

	Vector3 finalAim;
	Vector3 previousAim;
	Vector3 nextAim;
	bool isSubMoving;
	Stack<Vector3> chosenMove;
	float timeForSubMove;
	bool isOnFirstSubMove;

	public void Move(Vector3 delta)
	{
		if(isMoving)
		{
			return;
		}

		foreach(Stack<Vector3> move in moveSet)
		{
			if(delta == move.Peek())
			{
				isMoving = true;
				chosenMove = new Stack<Vector3>(new Stack<Vector3>(move));
				finalAim = chosenMove.Pop() * Field.fieldCellL + transform.position;
				isOnFirstSubMove = true;

				return;
			}
		}
	}

	private void Update()
	{
		if(isMoving)
		{
			if(!isSubMoving)
			{
				nextAim = chosenMove.Pop() * Field.fieldCellL + transform.position;
				previousAim = transform.position;
			}

			if(finalAim == transform.position)
			{
				isMoving = false;
				return;
			}

			float rad0, rad1;

			if(isOnFirstSubMove)
			{
				rad0 = 0;
			}
			else
			{
				rad0 = Mathf.PI / 2;
			}

			if(chosenMove.Count==0)
			{
				rad1 = Mathf.PI;
			}
			else
			{
				rad1 = Mathf.PI / 2;
			}

			transform.position = NatureLerp(previousAim, nextAim, (nextAim - previousAim).magnitude / Field.fieldCellL, rad0, rad1);

			if(nextAim == transform.position)
			{
				isSubMoving = false;
				isOnFirstSubMove = false;
			}
		}
	}

	Vector3 NatureLerp(Vector3 A, Vector3 B, float t, float rad0, float rad1)
	{
		return Vector3.Lerp(A, B, (float)Math.Sin((t * rad1 + rad0)));
	}
}
