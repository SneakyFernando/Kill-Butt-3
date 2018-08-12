using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class GlowShell : MonoBehaviour
{
	private void Start()
	{
		foreach(MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
		{
			rendr.material.renderQueue = 2002;
		}
	}
}

