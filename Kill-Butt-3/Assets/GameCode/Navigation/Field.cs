using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class Field : MonoBehaviour
{
	public static int N = 8;
	public static float fieldCellL = 4.5f;

	private void Start()
	{
		foreach(var t in transform.GetComponentsInChildren<Transform>())
		{
			string x = (t.position.x / 4.5f).ToString();
			string z = (t.position.z / 4.5f).ToString();
			t.name = "[" + x + ":" + z + "]";
		}
	}
}
