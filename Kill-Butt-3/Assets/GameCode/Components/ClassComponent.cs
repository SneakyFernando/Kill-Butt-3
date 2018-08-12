using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class ClassComponent : MonoBehaviour
{
	public UnitClass unitClass;

	public virtual void PreCalculate()
	{

	}

	public virtual float Calculate(Unit left, Unit right, float deltaLeft)
	{
		return deltaLeft;
	}

	public virtual void PostCalculate()
	{

	}
}

