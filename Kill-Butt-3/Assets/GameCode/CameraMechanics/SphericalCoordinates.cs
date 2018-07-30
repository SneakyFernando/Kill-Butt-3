using UnityEngine;
using System;

class SphericalCoordinates
{
	public static Vector3 HeilSphericalCoordinateSystem(float Theta, float Phi, float r)
	{
		float d2r = Mathf.Deg2Rad;
		Theta *= d2r;
		Phi *= d2r;
		float x = r * (float)Math.Sin(Theta) * (float)Math.Cos(Phi);
		float z = r * (float)Math.Sin(Theta) * (float)Math.Sin(Phi);
		float y = r * (float)Math.Cos(Theta);

		return new Vector3(x, y, z);
	}

	public static dVector3 X(double Theta, double Phi, double r)
	{
		double x = r * Math.Sin(Theta) * Math.Cos(Phi);
		double y = r * Math.Sin(Theta) * Math.Sin(Phi);
		double z = r * Math.Cos(Theta);

		return new dVector3(x, y, z);
	}

	public static Vector3 SystemCoordinateSphericalHeil(Vector3 vector)
	{
		float r = vector.magnitude;

		if(r == 0)
		{
			return Vector3.zero;
		}

		float r2d = Mathf.Rad2Deg;
		float theta = (float)Math.Acos(vector.y / r) * r2d;
		float phi;

		if(theta == 0 || theta == 180)
		{
			phi = 0;
		}
		else
		{
			phi = (float)Math.Atan2(vector.z, vector.x) * r2d;
		}

		return new Vector3(theta, phi, r);
	}

	public static dVector3 Y(dVector3 vector)
	{
		double r = vector.magnitude;

		if(r == 0)
		{
			return dVector3.zero;
		}

		double theta = Math.Acos(vector.z / r);
		double phi;

		if(theta == 0 || theta == Math.PI)
		{
			phi = 0;
		}
		else
		{
			phi = Math.Atan2(vector.y, vector.x);
		}

		return new dVector3(theta, phi, r);
	}

	public static float ClampTheta(float angle, float upLimit, float downLimit)
	{
		return Mathf.Clamp(angle, upLimit, downLimit);
	}

	public static float ClampPhi(float angle)
	{
		if(angle < 0f)
		{
			return angle += 360f;
		}

		if(angle > 360f)
		{
			return angle -= 360f;
		}

		return angle;
	}
}