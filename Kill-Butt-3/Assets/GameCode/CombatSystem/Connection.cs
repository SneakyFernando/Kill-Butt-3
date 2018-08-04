using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class Connection
{
	public Transform a;
	public Transform b;

	public Connection(Transform a, Transform b)
	{
		this.a = a;
		this.b = b;
		OnChange();
	}

	void OnChange()
	{

	}
}

