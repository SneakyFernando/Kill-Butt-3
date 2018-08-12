using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PawnMoveComponent : MoveComponent
{
	protected override void Initialize()
	{
		base.Initialize();

		moveSet = new List<Stack<Vector3>>();

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

	public override void UpdateUnderAttack()
	{
		connected = new List<MoveComponent>();

		for(int i = -1; i < 2; i += 2)
		{
			Vector3 attackPointRel = Snap(Quaternion.AngleAxis(45 * i, Vector3.up) * transform.forward);
			Vector2 attackPoint = new Vector2(attackPointRel.x + gridPos.x, attackPointRel.z + gridPos.y);
			int x = (int)attackPoint.x;
			int y = (int)attackPoint.y;

			if(x > Field.Nx - 1 || y > Field.Nx - 1 || x < 0 || y < 0)
			{
				continue;
			}

			if(Field.grid[x, y] != null)
			{
				if(Field.grid[x, y].gridPos == attackPoint)
				{
					connected.Add(Field.grid[x, y]);
				}
			}
		}

		base.UpdateUnderAttack();
	}
}
