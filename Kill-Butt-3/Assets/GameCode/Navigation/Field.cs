using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class Field : MonoBehaviour
{
	public static int N = 8;

	public static Unit[,] grid;

	private void Start()
	{
		grid = new Unit[N, N];
	}

	public static Unit Get(Vector3 pos)
	{
		return grid[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z)];
	}

	public static void Set(Unit unit, Vector3 pos)
	{
		unit.gridPos.x = Mathf.RoundToInt(pos.x);
		unit.gridPos.y = Mathf.RoundToInt(pos.z);
		grid[(int)unit.gridPos.x, (int)unit.gridPos.y] = unit;
	}
}
