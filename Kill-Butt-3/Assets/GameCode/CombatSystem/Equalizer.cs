using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class Equalizer : MonoBehaviour
{
	public static Dictionary<int, Pair> cache;
	public static Dictionary<int, Pair> cacheOld;

	private void Start()
	{
		cache = new Dictionary<int, Pair>();
	}

	private void Update()
	{
		GatherData();
		HandleGameObjects();
		Math();
	}

	void GatherData()
	{
		cacheOld = new Dictionary<int, Pair>(cache);
		cache = new Dictionary<int, Pair>();

		foreach(Unit unit in GameController.units)
		{
			unit.Move.UpdateUnderAttack();
		}

		foreach(Unit a in GameController.units)
		{
			foreach(Unit b in a.connected)
			{
				if(!a || !b)
				{
					continue;
				}

				if(a.Move.isMoving || b.Move.isMoving)
				{
					continue;
				}

				int uniquePairNumber = SecretNumber(a.gameObject.GetInstanceID(), b.gameObject.GetInstanceID());

				if(cache.ContainsKey(uniquePairNumber))
				{
					continue;
				}


				//if((a.isEnemy != b.isEnemy && (a.Class.unitClass == UnitClass.Carry || b.Class.unitClass == UnitClass.Carry)))
				{
					cache.Add(uniquePairNumber, new Pair(a, b));
					continue;
				}

				//Debug.Log((a.isEnemy == true ? "black" : "white") + " " + a.name + a.GetInstanceID());
				//Debug.Log((b.isEnemy == true ? "black" : "white") + " " + b.name + b.GetInstanceID());
				//Debug.Log(uniquePairNumber);
			}
		}
	}

	void HandleGameObjects()
	{
		foreach(var entry in cacheOld)
		{
			if(!cache.Contains(entry))
			{
				Unit a = entry.Value.a;
				Unit b = entry.Value.b;

				if(a)
				{
					if(a.bridgesByUnits.ContainsKey(b))
					{		
						a.BreakConnectionWith(b);
					}
				}

				if(b)
				{
					if(b.bridgesByUnits.ContainsKey(a))
					{			
						b.BreakConnectionWith(a);
					}
				}
			}
		}

		foreach(var entry in cache)
		{
			Unit a = entry.Value.a;
			Unit b = entry.Value.b;

			if(!a || !b)
			{
				continue;
			}

			if(!cacheOld.Contains(entry))
			{
				Unit attacker = a.unitFaction == UnitFaction.Red ? a : b;
				Unit target = a.unitFaction == UnitFaction.Red ? b : a;

				GameObject bridgeGO = new GameObject();
				bridgeGO.transform.SetParent(attacker.transform);
				attacker.bridgesByUnits.Add(target, bridgeGO.transform);
				bridgeGO.AddComponent<FlowBridge>().SetAndEnable(attacker, target);
			}
		}
	}

	void Math()
	{
		foreach(var entry in cache)
		{
			Unit a = entry.Value.a;
			Unit b = entry.Value.b;

			if(!a || !b)
			{
				continue;
			}
			HeatTransferManager.TransferHeatBetweenUnits(a, b);
		}
	}

	int SecretNumber(int a, int b)
	{
		int m = (a + b + 1) * (a + b) / 2 + b;
		int n = (b + a + 1) * (b + a) / 2 + a;
		return (m +n)/2;
	}

	public struct Pair
	{
		public Unit a;
		public Unit b;

		public Pair(Unit a, Unit b)
		{
			this.a = a;
			this.b = b;
		}
	}
}
