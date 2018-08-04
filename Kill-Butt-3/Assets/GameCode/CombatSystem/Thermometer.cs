using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class Thermometer
{
	public Unit unit;
	Material material;

	public Thermometer(Unit unit)
	{
		this.unit = unit;
		MeshRenderer mesh = unit.transform.GetComponent<MeshRenderer>();
		material = new Material(mesh.materials[0]);
	}

	public void Adjust(float temperature)
	{
		temperature /= 10000;

		material.color = Color.HSVToRGB(temperature *1200, .9f, .9f);
	}
}

