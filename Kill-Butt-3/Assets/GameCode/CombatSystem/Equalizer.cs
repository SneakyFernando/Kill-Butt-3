using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Equalizer : MonoBehaviour
{
	private void Update()
	{

	}

	void Equalise()
	{
		foreach(Unit a in GameController.units)
		{
			foreach(Unit b in GameController.units)
			{
				if(a == b)
				{
					continue;
				}


			}
		}
	}
}
