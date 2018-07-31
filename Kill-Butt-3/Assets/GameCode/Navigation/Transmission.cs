using UnityEngine;
using System.Collections.Generic;

class Transmission
{
	float accelerationTime = .2f;
	float timeStep = .1f;
	public float speed;
	public float acceleration;

	public static UpdatePosition

	public void MeasureSpeed(Transmission transmission)
	{
		transmission.speed = Mathf.SmoothDamp(transmission.speed, GetSpeedMultiplyer(transmission), ref transmission.acceleration, accelerationTime);
	}

	public float GetSpeedMultiplyer(Transmission transmission)
	{
		float remainingDistance = 0;

		if(remainingDistance > 2f)
		{
			return 1f;
		}
		if(remainingDistance < .01f)
		{
			return 0;
		}

		return .1f;
	}
}