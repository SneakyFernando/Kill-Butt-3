using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TankClassComponent : ClassComponent
{
	public override float Calculate(Unit left, Unit right, float deltaLeft)
	{
		//var count = left.connected.Count(u => u.IsEnemyFactionOf(left));

		//return deltaLeft * (1 / count * 0.1f);
		return deltaLeft;
	}
}
