using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimplePawn : MeshManipulator
{
	float t1 = 0;
	float t2 = .2f;
	Transform a, b, c, d, e, f;
	Vector3 a0, b0, c0, d0, e0, f0;
	float l = 1f;
	float direction = 1;
	int r1 = 0;
	int r2 = 1;
	int r3 = 2;
	float sineBoost;


	protected override void SetUp()
	{
		base.SetUp();

		coreElement = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		coreElement.position = Vector3.zero;
		coreElement.localScale = new Vector3(.13f, .13f, .13f);

		sinks = new List<HeatSink>();

		Vector3 scale = new Vector3(2, 2, 6);
		float offset = 1.2f;

		a = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		a0 = new Vector3(0, 2 * offset, 0);
		a.position = a0;
		a.localScale = scale;
		a.eulerAngles = new Vector3(0, 0, 0);
		sinks.Add(a.gameObject.AddComponent<HeatSink>());
		a.name = "a";

		b = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		b0 = new Vector3(0, -2 * offset, 0);
		b.position = b0;
		b.localScale = scale;
		a.eulerAngles = new Vector3(0, 180, 0);
		sinks.Add(b.gameObject.AddComponent<HeatSink>());
		b.name = "b";

		c = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		c0 = new Vector3(2 * offset, 0, 0);
		c.position = c0;
		c.localScale = scale;
		c.eulerAngles = new Vector3(90, 0, 0);
		sinks.Add(c.gameObject.AddComponent<HeatSink>());
		c.name = "c";

		d = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		d0 = new Vector3(-2 * offset, 0, 0);
		d.position = d0;
		d.localScale = scale;
		d.eulerAngles = new Vector3(-90, 0, 0);
		sinks.Add(d.gameObject.AddComponent<HeatSink>());
		d.name = "d";

		e = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		e0 = new Vector3(0, 0, 2 * offset);
		e.position = e0;
		e.localScale = scale;
		e.eulerAngles = new Vector3(0, 90, 0);
		sinks.Add(e.gameObject.AddComponent<HeatSink>());
		e.name = "e";

		f = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		f0 = new Vector3(0, 0, -2 * offset);
		f.position = f0;
		f.localScale = scale;
		f.eulerAngles = new Vector3(0, -90, 0);
		sinks.Add(f.gameObject.AddComponent<HeatSink>());
		f.name = "f";

		for(int i = 0; i < 6; i++)
		{
			sinks[i].transform.SetParent(transform);
		}

		transform.localScale = new Vector3(.08f, .08f, .08f);
		coreElement.SetParent(transform);
	}

	protected override void Animate()
	{
		base.Animate();

	}


	protected override void HandleTicks()
	{
		base.HandleTicks();

		t1 += Time.deltaTime / 2;
	}
}

