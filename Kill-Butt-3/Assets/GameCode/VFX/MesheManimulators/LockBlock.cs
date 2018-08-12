//using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LockBlock : MeshManipulator
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
		a0 = new Vector3(0, 2* offset, 0);
		a.position = a0;
		a.localScale = scale;
		a.eulerAngles = new Vector3(0, 0, 0);
		sinks.Add(a.gameObject.AddComponent<HeatSink>());
		a.name = "a";

		b = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		b0 = new Vector3(0, -2* offset, 0);
		b.position = b0;
		b.localScale = scale;
		a.eulerAngles = new Vector3(0, 180, 0);
		sinks.Add(b.gameObject.AddComponent<HeatSink>());
		b.name = "b";

		c = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		c0 = new Vector3(2* offset, 0, 0);
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
		f.eulerAngles = new Vector3(0,-90, 0);
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

		//if(t1<.5f)
		//{
			Rotate(r1);
			//Rotate(r2);
		//}

		//if(t2>.5f)
		//{
			//Rotate(r3);
		//}
	}

	void Rotate(int counter)
	{
		//if(counter == 0)
		//{
			RotateAB();
			RotateCD();
		//}

		//if(counter == 1)
		//{
		RotateEF();
		//}

		//if(counter == 2)
		//{
		//	RotateEF();
		//	RotateAB();
		//}
	}

	void RotateAB()
	{
		if(sinks[0].isActive || a.transform.localPosition != a0)
		{
			a.transform.localPosition = a0 + sineBoost * a.transform.forward;
		}

		if(sinks[1].isActive || b.transform.localPosition != b0)
		{
			b.transform.localPosition = b0 + sineBoost * b.transform.forward;
		}
	}

	void RotateCD()
	{
		if(sinks[2].isActive || c.transform.localPosition != c0)
		{
			c.transform.localPosition = c0 + sineBoost * c.transform.forward;
		}

		if(sinks[3].isActive || d.transform.localPosition != d0)
		{
			d.transform.localPosition = d0 + sineBoost * d.transform.forward;
		}
	}

	void RotateEF()
	{
		if(sinks[4].isActive || e.transform.localPosition != e0)
		{
			e.transform.localPosition = e0 + sineBoost * e.transform.forward;
		}

		if(sinks[5].isActive || f.transform.localPosition != f0)
		{
			f.transform.localPosition = f0 + sineBoost * f.transform.forward;
		}
	}

	bool isDirty = false;

	protected override void HandleTicks()
	{
		base.HandleTicks();

		//float sineBoost = Mathf.Cos(t2 * Mathf.PI * 2);

		//if(sineBoost>0)
		//{
		t1 += Time.deltaTime / 2;
		t2 += Time.deltaTime / 2;
		//}
		//else
		//{
		//	t1 = Time.deltaTime * (sineBoost) / 1;
		//}

		//if(t1 >= 1)
		//{
		//	t1 = 1;
		//}

		//if(t1 <= -1)
		//{

		//	t1 = -1;
		//}

		if(!isDirty)
		{
			if(t1<.5f)
			{
				//direction = Random.value < .5f ? -1 : 1;
				isDirty = true;
			}
		}

		if(t1 > 1)
		{
			t1 = 0;
			isDirty = false;

			//while(r1 == r2 && r1 == r3 )
			//{
			//	r1 = Random.Range(0, 3);
			//}

			//while(r2 == r1 && r2 == r3)
			//{
			//	r2 = Random.Range(0, 3);
			//}

			//while(r3 == r1 && r3 == r2)
			//{
			//	r3 = Random.Range(0, 3);
			//}
			r1++;
			if(r1==2)
			{
				r1 = 0;
			}
		}

		sineBoost = direction*(Mathf.Sin(t1 * Mathf.PI * 2) )* l * 2;
		//t2 += Time.deltaTime;

		if(t2 > 1)
		{
			t2 = 0;
		}


	}
}

