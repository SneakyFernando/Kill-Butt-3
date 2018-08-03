using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Bishop : Unit
{
	private void Start()
	{
		moveSet = new List<Stack<Vector3>>();

		for(int i = 1; i < 9; i+=2)
		{
			for(int j = 1; j < 9; j++)
			{
				Stack<Vector3> move = new Stack<Vector3>();

				for(int k = 0; k < j; k++)
				{
					Vector3 direction = Dispatcher.Snap(Quaternion.AngleAxis(45 * i, Vector3.up) * Vector3.forward);

					move.Push(direction);
				}

				Vector3 lastKey = Dispatcher.Snap(Quaternion.AngleAxis(45 * i, Vector3.up) * Vector3.forward) * j;
				move.Push(lastKey);

				moveSet.Add(move);
			}
		}
	}
}
