using UnityEngine;
using System.Collections;

static class Engine
{
	public static void MoveToAim(Transmission transmission) //перемещение в точку 
	{
		transmission.navAgent.SetDestination(transmission.Aim);
		transmission.unit.StartCoroutine(AnimationDamping(transmission));
	}

	static IEnumerator AnimationDamping(Transmission transmission) //сглаживает переход анимации с ходьбы на бег и назад
	{
		while(transmission.isMoving)
		{
			Speedometer.MeasureSpeed(transmission);

			transmission.motionAccess.cerebellum.animator.SetFloat("Speed", transmission.speed);
			Vector3 p = transmission.unit.transform.position;
			p.y = 0;

			if(p == transmission.Aim && Speedometer.GetSpeedMultiplyer(transmission) == 0)
			{
				transmission.motionAccess.cerebellum.animator.SetFloat("Speed", 0);
				transmission.isMoving = false;
			}

			yield return null;
		}

		yield return null;
	}
}