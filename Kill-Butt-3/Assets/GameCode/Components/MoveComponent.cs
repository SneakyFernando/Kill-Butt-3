using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
	public bool isMoving;
	public Vector2 gridPos;
	public Unit unit;

	protected List<Stack<Vector3>> moveSet;
	protected List<MoveComponent> connected = new List<MoveComponent>();

	Vector3 startPos;
	Vector3 finalAim;
	Vector3 previousAim;
	Vector3 nextAim;
	bool isSubMoving;
	Stack<Vector3> chosenMove;
	bool isOnFirstSubMove;
	float t;
	float timeForSubMove = .5f;

	Vector3 pos
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
		unit = GetComponent<Unit>();
		Initialize();
	}

	protected virtual void Initialize()
	{
		gridPos = new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z));
		pos = new Vector3(gridPos.x, .5f, gridPos.y);
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
		Vector3 delta = Snap(deltaNotPrecise);

		foreach(Stack<Vector3> move in moveSet)
		{
			if(!IsWayEmpty(move, pos))
			{
				continue;
			}

			Vector3 checkPos = move.Peek();

			if(delta == checkPos)
			{
				isMoving = true;
				chosenMove = new Stack<Vector3>(new Stack<Vector3>(move));
				startPos = pos;
				finalAim = chosenMove.Pop() + pos;
				isOnFirstSubMove = true;
				Field.Set(null, startPos);

				return;
			}
		}
	}

	IEnumerator MergeSmoothly()
	{
		float t = 0;
		int counter = 0;

		while(counter < 5)
		{
			float lerpY = Mathf.Lerp(Mathf.FloorToInt(transform.position.y), Mathf.FloorToInt(transform.position.y) - 1, t);
			transform.position = new Vector3(0, lerpY, 0);

			if(t > 1)
			{
				t = 0;
				counter++;
			}

			yield return null;
		}

		yield return null;
	}

	public void Move()
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
			float t1 = t/timeForSubMove;

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
					Field.Set(this, finalAim);
				}
			}

		}
	}

	public static bool IsWayEmpty(Stack<Vector3> referencedPath, Vector3 position0)
	{
		return true;
		//Stack<Vector3> path = new Stack<Vector3>(new Stack<Vector3>(referencedPath));
		//path.Pop();
		//int N = path.Count;
		//Vector3 temp = Vector3.zero;

		//for(int i = 0; i < N; i++)
		//{
		//	temp += path.Pop();
		//	Vector3 d0 = position0 + temp * Field.fieldCellL;
		//	Debug.DrawLine(d0 + Vector3.up * 10, d0 + Vector3.up * 1, Color.cyan, 10);

		//	if(Physics.Raycast(d0 + Vector3.up * 10, d0 + Vector3.up * 1))
		//	{
		//		return false;
		//	}
		//}

		//return true;
	}

	public static Vector3 Snap(Vector3 v)
	{
		return new Vector3(Mathf.RoundToInt(v.x), 0, Mathf.RoundToInt(v.z));
	}

	public virtual void UpdateUnderAttack()
	{
		unit.connected = new List<Unit>();

		foreach(MoveComponent move in connected)
		{
			unit.connected.Add(move.unit);
		}
	}
}

