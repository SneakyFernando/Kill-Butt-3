using UnityEngine;

static class Speedometer
{
	static float accelerationTime = .2f;
	static float timeStep = .1f;

	public static void MeasureSpeed(Transmission transmission)
	{
		transmission.speed = Mathf.SmoothDamp(transmission.speed, GetSpeedMultiplyer(transmission), ref transmission.acceleration, accelerationTime);
	}

	public static float GetSpeedMultiplyer(Transmission transmission)
	{
		float remainingDistance = transmission.navAgent.remainingDistance;

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