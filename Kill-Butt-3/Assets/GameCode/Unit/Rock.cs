using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Rock : Unit
{
	private void Start()
	{
		moveSet = new List<Stack<Vector3>>();

		for(int i = 0; i < 4; i++)
		{
			for(int j = 1; j < 9; j++)
			{
				Stack<Vector3> move = new Stack<Vector3>();

				for(int k = 0; k < j; k++)
				{
					Vector3 direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward);

					move.Push(direction);
				}

				Vector3 lastKey = Dispatcher.Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward) * j;
				move.Push(lastKey);

				moveSet.Add(move);
			}
		}
	}
}
