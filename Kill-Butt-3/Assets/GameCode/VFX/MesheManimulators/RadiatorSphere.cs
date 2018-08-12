using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadiatorSphere : MeshManipulator
{
	int heatSinksN = 8;

	float t1 = 0;
	float t2 = 0;
	//bool t2Direction = true;
	float tilt = 30;
	float sineBoostMax = 0.5f;

	float k;

	protected override void SetUp()
	{
		base.SetUp();

		coreElement = Instantiate(Resources.Load("TestModels/Sphere") as GameObject).transform;
		coreElement.position = Vector3.zero;
		coreElement.SetParent(transform);
		coreElement.localScale = new Vector3(1f, 1f, 1f);
		float heatSinksSizeMultiplier = 1f;

		k = 1f / (heatSinksN -1);
		float m = k * 2 / 3;
		float ri = 1f /( heatSinksN-1);

		sinks = new List<HeatSink>();

		for(int i = 0; i < heatSinksN; i++)
		{
			GameObject heatSinkObject = new GameObject("Heat Sink");

			float l = (i) * ri;

			float r1 = Mathf.Sqrt(l * (1 - l))* heatSinksSizeMultiplier;

			if(i == 0 || i == heatSinksN - 1)
			{
				r1 = .2f;
			}

			Transform a = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
			a.transform.position = new Vector3(r1, 0, 0);
			a.localScale = new Vector3(m, m, r1 * 2+m);

			Transform b = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
			b.transform.position = new Vector3(0, 0, r1);
			b.localScale = new Vector3(r1 * 2 + m , m, m);

			Transform c = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
			c.transform.position = new Vector3(-r1, 0, 0);
			c.localScale = new Vector3(m, m, r1 * 2 + m );
			
			Transform d = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
			d.transform.position = new Vector3(0, 0, -r1);
			d.localScale = new Vector3(r1 * 2 + m , m, m);

			a.transform.SetParent(heatSinkObject.transform);
			b.transform.SetParent(heatSinkObject.transform);
			c.transform.SetParent(heatSinkObject.transform);
			d.transform.SetParent(heatSinkObject.transform);

			heatSinkObject.transform.position = new Vector3(0, k * i - .5f, 0);
			heatSinkObject.transform.SetParent(transform);
			HeatSink heatSink = heatSinkObject.AddComponent<HeatSink>();

			sinks.Add(heatSink);
		}

		k = 1f / (heatSinksN - 2);

		transform.localScale = new Vector3(.5f, .5f, .5f);
	}

	protected override void Animate()
	{
		base.Animate();

		transform.eulerAngles = new Vector3(tilt, t1 * 360, 0);

		for(int i = 0; i < sinks.Count; i++)
		{
			if(sinks[i].isActive)
			{
				float angle = 360 * t2 + i * k * 60;
				sinks[i].transform.localEulerAngles = new Vector3(0, angle, 0);
			}
			else
			{
				float angle = 360 * t2;
				sinks[i].transform.localEulerAngles = new Vector3(0, angle, 0);
			}
		}
	}

	protected override void HandleTicks()
	{
		base.HandleTicks();

		float sineBoost = Mathf.Sin(t1 * Mathf.PI * 2) + 1;
		t1 += Time.deltaTime * (1 + sineBoostMax * sineBoost) / 10;

		if(t1 > 1)
		{
			t1 = 0;
		}

		//float sineBoost = Mathf.Sin(t1 * Mathf.PI * 2) + 1;
		t2 += Time.deltaTime / 10;

		if(t2 > 1)
		{
			t2 = 0;
		}
	}
}

