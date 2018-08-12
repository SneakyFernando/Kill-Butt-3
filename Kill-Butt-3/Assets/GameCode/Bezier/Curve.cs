using UnityEngine;

public class Curve
{
	public Vector3[] orderPoints;
	public Vector3[] points;
	public int order;
	public float maxRadius;
	public Vector3 randomizeVector;
	public int orderPointsAmount;
	public int pointsAmount;

	public Curve(int orderPointsAmount, int order, int pointsAmount, float maxRadius, Vector3 randomizeVector)
	{
		this.orderPointsAmount = orderPointsAmount;
		this.order = order;
		this.pointsAmount = pointsAmount;
		this.maxRadius = maxRadius;
		this.randomizeVector = randomizeVector;
	}

	public void RecomputeRandomized()
	{
		if(orderPoints == null)
		{
			orderPoints = OrderPoints.BuildRandomized(this);
		}

		points = PointsFiller.Fill(orderPoints, order, pointsAmount);
	}

	public void RecomputeWithOrderPoints(Vector3[] orderPoints)
	{
		this.orderPoints = orderPoints;
		points = PointsFiller.Fill(orderPoints, order, pointsAmount);
	}
}
