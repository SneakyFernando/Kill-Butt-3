using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Queen : Unit
{
	private void Start()
	{
		moveSet = new List<Stack<Vector3>>();

		for(int i = 0; i < 8; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();

			for(int j = 0; j < 8; j++)
			{
				for(int k = 0; k < j; k++)
				{

				}
			}
		}

		Stack<Vector3> onego = new Stack<Vector3>();
		onego.Push(transform.forward);
		onego.Push(transform.forward);
		Stack<Vector3> doublego = new Stack<Vector3>();
		doublego.Push(transform.forward);
		doublego.Push(transform.forward);
		doublego.Push(transform.forward * 2);

		moveSet.Add(onego);
		moveSet.Add(doublego);
	}
}
