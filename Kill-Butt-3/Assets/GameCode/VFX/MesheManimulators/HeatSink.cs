using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeatSink : MonoBehaviour
{
	public bool isActive;

	public void ApplyMaterial(Material material)
	{
		isActive = material.name.Contains("On");

		MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

		foreach(var renderer in renderers)
		{
			renderer.material = material;
		}
	}
}

