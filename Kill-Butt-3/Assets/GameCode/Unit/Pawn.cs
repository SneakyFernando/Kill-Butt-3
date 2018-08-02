using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Pawn : Unit
{
	private void Start()
	{
		moveSet = new List<Stack<Vector3>>();

		Stack<Vector3> onego = new Stack<Vector3>();
		onego.Push(transform.forward);
		onego.Push(transform.forward);
		Stack<Vector3> doublego = new Stack<Vector3>();
		doublego.Push(transform.forward);
		doublego.Push(transform.forward);
		doublego.Push(transform.forward*2);

		moveSet.Add(onego);
		moveSet.Add(doublego);
	}
}
