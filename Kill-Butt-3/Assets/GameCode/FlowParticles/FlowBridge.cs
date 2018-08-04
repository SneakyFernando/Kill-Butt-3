using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class FlowBridge
{
	public Curve curve;
	public GameObject particesGO;
	public ParticleSystem partices;

	public FlowBridge(Transform a, Transform b)
	{
		//curve = new Curve(4, 4, 100, 1, new Vector3(1, 1, 1));
		particesGO = Object.Instantiate(Resources.Load("HeatFlow"), FlowController.particlesController) as GameObject;
		partices.GetComponent<ParticleSystem>();
	}
}
