using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Thermometer
{
	public Unit unit;
	Material material;
	MeshRenderer mesh;
	float minEmission;
	float maxEmission;
	Color baseColor;
	float minT;
	float maxT;
	float range;

	public Thermometer(Unit unit)
	{
		this.unit = unit;
		return;
		//mesh = unit.transform.GetComponent<MeshRenderer>();
		//material = mesh.materials[0];
		//material.EnableKeyword("_EMISSION");
		//minEmission = 0;
		
		//maxEmission = unit.isEnemy ? 6 : 4;
		//baseColor = unit.isEnemy ? new Color(1, 0, 0, 1) : new Color(0, 1, 1, 1);
		//minT = unit.isEnemy ? 0 : HeatSystem.maxT * (.5f + HeatSystem.thresholdDelta);
		//maxT = unit.isEnemy ? HeatSystem.maxT * (.5f - HeatSystem.thresholdDelta) : HeatSystem.maxT;
		//range = HeatSystem.maxT * (.5f - HeatSystem.thresholdDelta);
	}

	public void Adjust(float temperature)
	{
		return;
		//temperature = (temperature - minT)/range;
		//float intensity = (maxEmission - minEmission) * temperature + minEmission;
		//Color finalColor = baseColor * intensity;
		//material.SetColor("_EmissionColor", finalColor);
		//mesh.materials[0] = material;
	}
}

