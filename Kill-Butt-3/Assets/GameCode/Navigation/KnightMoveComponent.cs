using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class KnightMoveComponent : MoveComponent
{
	protected override void Initialize()
	{
		base.Initialize();

		moveSet = new List<Stack<Vector3>>();

		for(int i = 0; i < 8; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();

			Vector3 direction = Snap(Quaternion.AngleAxis(90 * (i / 2), Vector3.up) * Vector3.forward);
			Vector3 lastKey = direction;

			move.Push(direction);

			direction = Snap(Quaternion.AngleAxis(90 * (i / 2 + 1 + -2 * (i % 2)), Vector3.up) * Vector3.forward);
			lastKey += direction;
			lastKey += direction;
			move.Push(direction);
			move.Push(direction);
			move.Push(lastKey);
			moveSet.Add(move);
		}

		for(int i = 0; i < 8; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();

			Vector3 direction = Snap(Quaternion.AngleAxis(90 * (i / 2), Vector3.up) * Vector3.forward);
			Vector3 lastKey = direction;

			move.Push(direction);
			move.Push(direction);
			lastKey += direction;

			direction = Snap(Quaternion.AngleAxis(90 * (i / 2 + 1 + -2 * (i % 2)), Vector3.up) * Vector3.forward);
			lastKey += direction;
			move.Push(direction);
			move.Push(lastKey);
			moveSet.Add(move);
		}
	}

	public override void UpdateUnderAttack()
	{
		connected = new List<MoveComponent>();

		for(int i = 0; i < 8; i++)
		{
			Vector3 direction = Snap(Quaternion.AngleAxis(90 * (i / 2), Vector3.up) * Vector3.forward);
			Vector3 attackPointRel = direction;
			attackPointRel += Snap(Quaternion.AngleAxis(90 * (i / 2 + 1 + -2 * (i % 2)), Vector3.up) * Vector3.forward) * 2;
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

		for(int i = 0; i < 8; i++)
		{
			Vector3 direction = Snap(Quaternion.AngleAxis(90 * (i / 2), Vector3.up) * Vector3.forward);
			Vector3 attackPointRel = direction * 2;
			attackPointRel += Snap(Quaternion.AngleAxis(90 * (i / 2 + 1 + -2 * (i % 2)), Vector3.up) * Vector3.forward);
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
