using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class RockMoveComponent : MoveComponent
{
	protected override void Initialize()
	{
		base.Initialize();

		moveSet = new List<Stack<Vector3>>();

		for(int i = 0; i < 4; i++)
		{
			for(int j = 1; j < 9; j++)
			{
				Stack<Vector3> move = new Stack<Vector3>();

				for(int k = 0; k < j; k++)
				{
					Vector3 direction = Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward);

					move.Push(direction);
				}

				Vector3 lastKey = Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward) * j;
				move.Push(lastKey);

				moveSet.Add(move);
			}
		}
	}

	public override void UpdateUnderAttack()
	{
		connected = new List<MoveComponent>();

		for(int i = 0; i < 4; i++)
		{
			for(int j = 1; j < 9; j++)
			{
				Vector3 attackPointRel = Snap(Quaternion.AngleAxis(90 * i, Vector3.up) * Vector3.forward) * j;
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
							j = int.MaxValue;
							goto end;
						}
					}
				}
			}

			end:
			continue;
		}

		base.UpdateUnderAttack();
	}
}
