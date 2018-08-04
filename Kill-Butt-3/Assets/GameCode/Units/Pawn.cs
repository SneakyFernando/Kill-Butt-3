using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Pawn : Unit
{
	protected override void Init()
	{
		base.Init();

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

	public override List<Unit> GetUnderAttack()
	{
		List<Unit> result = new List<Unit>();

		for(int i = 0; i < 8; i++)
		{
			for(int j = 1; j < 9; j++)
			{
				Vector3 lastKey = Dispatcher.Snap(Quaternion.AngleAxis(45 * i, Vector3.up) * Vector3.forward) * j;

				foreach(Unit other in GameController.units)
				{
					if(other.pos == pos + lastKey)
					{
						result.Add(other);
						j = int.MaxValue;
						break;
					}
				}
			}
		}

		return result;
	}
}
