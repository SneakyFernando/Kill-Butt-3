using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Dispatcher : MonoBehaviour
{
	public static Unit selectedAlly;

	private void Update()
	{
			
	}

	public static bool IsWayEmpty(Stack<Vector3> referencedPath, Vector3 position0)
	{
		Stack<Vector3> path = new Stack<Vector3>(new Stack<Vector3>(referencedPath));
		path.Pop();
		int N = path.Count;
		Vector3 temp = Vector3.zero;

		for(int i = 0; i < N; i++)
		{
			temp += path.Pop();
			Vector3 d0 = position0 + temp * Field.fieldCellL;
			Debug.DrawLine(d0 + Vector3.up * 10, d0 + Vector3.up * 1, Color.cyan, 10);

			if(Physics.Raycast(d0 + Vector3.up * 10, d0 + Vector3.up * 1))
			{
				return false;
			}
		}

		return true;
	}

	public static Vector3 Snap(Vector3 v)
	{
		return new Vector3(Mathf.RoundToInt(v.x), 0, Mathf.RoundToInt(v.z));
	}
}
