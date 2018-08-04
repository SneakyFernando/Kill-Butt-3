using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class Unit : MonoBehaviour
{
	public bool isEnemy;

	public bool isMoving;

	public float m = 1;
	public float c = 4200;
	public float T = 1000;

	public List<Stack<Vector3>> moveSet;
	public Vector2 gridPos;

	Vector3 finalAim;
	Vector3 previousAim;
	Vector3 nextAim;
	bool isSubMoving;
	Stack<Vector3> chosenMove;
	bool isOnFirstSubMove;
	float t;
	float timeForSubMove = 1;

	Thermometer thermometer;

	public Vector3 pos
	{
		get
		{
			return transform.position;
		}
		set
		{
			transform.position = value;
		}
	}

	private void Start()
	{
		Init();
		moveSet.Sort((m1, m2) => m1.Count.CompareTo(m2));
		thermometer = new Thermometer(this);
	}

	private void Update()
	{
		thermometer.Adjust(T);
	}

	private void FixedUpdate()
	{
		Move();
	}

	protected virtual void Init()
	{
		gridPos = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z));
		Field.grid[(int)gridPos.x, (int)gridPos.y] = this;
	}

	public void SetAim(Vector3 position)
	{
		if(isMoving)
		{
			return;
		}

		position.y = 0;
		Vector3 deltaNotPrecise = position - pos;
		Vector3 delta = Dispatcher.Snap(deltaNotPrecise);

		foreach(Stack<Vector3> move in moveSet)
		{	
			if(!Dispatcher.IsWayEmpty(move, pos))
			{
				continue;
			}

			Vector3 checkPos = move.Peek();

			if(delta == checkPos)
			{
				isMoving = true;
				chosenMove = new Stack<Vector3>(new Stack<Vector3>(move));
				finalAim = chosenMove.Pop() + pos;
				isOnFirstSubMove = true;

				return;
			}
		}
	}

	void Move()
	{
		if(isMoving)
		{
			if(!isSubMoving)
			{
				t = 0;
				isSubMoving = true;
				nextAim = chosenMove.Pop() + pos;
				previousAim = pos;
			}

			t += Time.fixedDeltaTime;
			float t1 = t;

			//if(isOnFirstSubMove)
			//{
			//	t1 = (float)Math.Sin(t * Math.PI / 2);
			//}

			//if(chosenMove.Count == 0)
			//{

			//	t1 = (float)Math.Sin(t * Math.PI / 2);
			//}

			pos = Vector3.Lerp(previousAim, nextAim, t1);

			if(t > timeForSubMove)
			{
				isSubMoving = false;
				isOnFirstSubMove = false;

				if(chosenMove.Count == 0)
				{
					isMoving = false;
				}
			}

			CheckForPositionSwap();
		}
	}

	void CheckForPositionSwap()
	{
		if((pos-nextAim).sqrMagnitude > (pos-previousAim).sqrMagnitude)
		{
			Field.Set(null, previousAim);
			Field.Set(this, nextAim);
		}
	}

	public virtual List<Unit> GetUnderAttack()
	{
		return null;
	}
}
