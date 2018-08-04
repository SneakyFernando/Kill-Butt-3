using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Queen : Unit
{
	protected override void Init()
	{
		base.Init();

		moveSet = new List<Stack<Vector3>>();

		for(int i = 0; i < 8; i++)
		{
			for(int j = 1; j < 9; j++)
			{
				Stack<Vector3> move = new Stack<Vector3>();

				for(int k = 0; k < j;  k++)
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

	public override List<Unit> GetUnderAttack()
	{
		List<Unit> results = new List<Unit>();

		for(int i = 0; i < 8; i++)
		{
			for(int j = 1; j < 9; j++)
			{   
				Vector3 attackPointRel = Dispatcher.Snap(Quaternion.AngleAxis(45 * i, Vector3.up) * Vector3.forward) * j;
				Vector2 attackPoint = new Vector2(attackPointRel.x + gridPos.x, attackPointRel.z + gridPos.y);

				for(int x = 0; x < Field.N; x++)
				{
					for(int y = 0; y < Field.N; y++)
					{
						if(Field.grid[x, y].gridPos == attackPoint)
						{
							results.Add(Field.grid[x,y]);
							j = int.MaxValue;
							goto end;
						}
					}
				}
			}

			end:
			continue;
		}

		return results;
	}
}
