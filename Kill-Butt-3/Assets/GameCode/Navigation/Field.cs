using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

static class Field
{
	public static int Nx = 8;
	public static int Ny = 16;

	public static MoveComponent[,] grid = new MoveComponent[Nx, Ny];

	public static MoveComponent Get(Vector3 pos)
	{
		return grid[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z)];
	}

	public static void Set(MoveComponent unit, Vector3 pos)
	{
		int x = Mathf.RoundToInt(pos.x);
		int y = Mathf.RoundToInt(pos.z);

		if(unit != null)
		{
			unit.gridPos.x = x;
			unit.gridPos.y = y;
		}

		grid[x, y] = unit;
	}
}
