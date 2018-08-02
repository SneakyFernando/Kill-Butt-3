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
	bool isOnFirstSubMove;
	float t;
	float timeForSubMove = 1;

	public Vector3 pos
	{
		get
		{
			return transform.parent.position;
		}
		set
		{
			transform.parent.position = value;
		}
	}

	public void Move(Vector3 position)
	{
		position.y = 0;
		Vector3 deltaNotPrecise = (position - pos) / Field.fieldCellL;
		Vector3 delta = new Vector3(Mathf.RoundToInt(deltaNotPrecise.x), 0, Mathf.RoundToInt(deltaNotPrecise.z));

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
				finalAim = chosenMove.Pop() * Field.fieldCellL + pos;
				isOnFirstSubMove = true;

				return;
			}
		}
	}

	private void FixedUpdate()
	{
		if(isMoving)
		{
			if(!isSubMoving)
			{
				t = 0;
				isSubMoving = true;
				nextAim = chosenMove.Pop() * Field.fieldCellL + pos;
				previousAim = pos;
			}

			t += Time.fixedDeltaTime;
			float t1 = t;

			if(isOnFirstSubMove)
			{
				t1 = (float)Math.Sin(t * Math.PI / 2);
			}

			if(chosenMove.Count==0)
			{

				t1 = (float)Math.Sin(t * Math.PI / 2);
			}
			 
			pos = NatureLerp(previousAim, nextAim, t1);

			if(t > timeForSubMove)
			{
				isSubMoving = false;
				isOnFirstSubMove = false;

				if(chosenMove.Count == 0)
				{
					isMoving = false;
				}
			}
		}
	}

	Vector3 NatureLerp(Vector3 A, Vector3 B, float t)
	{
		return Vector3.Lerp(A, B, t);
	}
}
