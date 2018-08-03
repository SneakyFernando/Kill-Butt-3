using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Knight : Unit
{
	private void Start()
	{
		moveSet = new List<Stack<Vector3>>();

		for(int i = 0; i < 4; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();

			Vector3 direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward);
			Vector3 lastKey = direction;

			move.Push(direction);

			direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * (i + 1), Vector3.up) * Vector3.forward);
			lastKey += direction;
			lastKey += direction;
			move.Push(direction);
			move.Push(direction);
			move.Push(lastKey);

			moveSet.Add(move);
		}

		for(int i = 0; i < 4; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();

			Vector3 direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward);
			Vector3 lastKey = direction;

			move.Push(direction);

			direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * (i - 1), Vector3.up) * Vector3.forward);
			lastKey += direction;
			lastKey += direction;
			move.Push(direction);
			move.Push(direction);
			move.Push(lastKey);

			moveSet.Add(move);
		}

		for(int i = 0; i < 4; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();

			Vector3 direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward);
			Vector3 lastKey = direction;


			move.Push(direction);
			move.Push(direction);
			lastKey += direction;

			direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * (i - 1), Vector3.up) * Vector3.forward);
			lastKey += direction;
			move.Push(direction);
			move.Push(lastKey);

			moveSet.Add(move);
		}

		for(int i = 0; i < 4; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();

			Vector3 direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward);
			Vector3 lastKey = direction;


			move.Push(direction);
			move.Push(direction);
			lastKey += direction;

			direction = Dispatcher.Snap(Quaternion.AngleAxis(90 * (i + 1), Vector3.up) * Vector3.forward);
			lastKey += direction;
			move.Push(direction);
			move.Push(lastKey);

			moveSet.Add(move);
		}
	}
}
