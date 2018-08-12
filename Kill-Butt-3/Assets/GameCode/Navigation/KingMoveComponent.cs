using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class KingMoveComponent : MoveComponent
{
	protected override void Initialize()
	{
		base.Initialize();

		moveSet = new List<Stack<Vector3>>();

		for(int i = 0; i < 8; i++)
		{
			Stack<Vector3> move = new Stack<Vector3>();
			Vector3 direction = Snap(Quaternion.AngleAxis(45 * i, Vector3.up) * Vector3.forward);

			move.Push(direction);
			move.Push(direction);

			moveSet.Add(move);
		}
	}

	public override void UpdateUnderAttack()
	{
		connected = new List<MoveComponent>();

		for(int i = 0; i < 8; i++)
		{
			Vector3 attackPointRel = Snap(Quaternion.AngleAxis(45 * i, Vector3.up) * Vector3.forward);
			Vector2 attackPoint = new Vector2(attackPointRel.x + gridPos.x, attackPointRel.z + gridPos.y);

			for(int x = 0; x < Field.Nx; x++)
			{
				for(int y = 0; y < Field.Nx; y++)
				{
					if(Field.grid[x, y] == null)
					{
						continue;
					}

					if(Field.grid[x, y].gridPos == attackPoint)
					{
						connected.Add(Field.grid[x, y]);
						goto end;
					}
				}
			}

			end:
			continue;
		}

		base.UpdateUnderAttack();
	}
}

