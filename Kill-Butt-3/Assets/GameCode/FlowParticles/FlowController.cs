using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class FlowController : MonoBehaviour
{
	public static Transform particlesController;

	private void Awake()
	{
		particlesController = transform;
	}
}

