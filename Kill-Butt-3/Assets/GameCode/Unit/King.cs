using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class King : Unit
{
	private void Start()
	{
		moveSet = new List<Stack<Vector3>>();

		for(int i = 0; i < 8; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();
			Vector3 direction = Dispatcher.Snap(Quaternion.AngleAxis(45 * i, Vector3.up) * Vector3.forward);

			move.Push(direction);
			move.Push(direction);

			moveSet.Add(move);
		}
	}
}

