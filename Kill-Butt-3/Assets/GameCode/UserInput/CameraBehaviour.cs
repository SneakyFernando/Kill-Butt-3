using UnityEngine;

class CameraBehaviour : MonoBehaviour
{
	public static float r = 10;
	public static float phi = 164;
	public static float theta = 64;
	public static float phiAxisSpeed = 5;
	public static float thetaAxisSpeed = 5;
	public static float rAxisSpeed = 8;

	public static float thethaMin = 1;
	public static float thethaMax = 90;
	public static float rMin = .5f;
	public static float rMax = 24;

	public static Camera camera;
	public Transform target;

	private void Start()
	{
		camera = GetComponent<Camera>();
	}

	private void LateUpdate()
	{
		RefreshTransform();
	}

	public static void ChangeDistance()
	{
		r = Mathf.Clamp(r - Input.GetAxis("Mouse ScrollWheel") * rAxisSpeed, rMin, rMax);
	}

	public static void ChangeAngle()
	{
		theta += Input.GetAxis("Mouse Y") * thetaAxisSpeed;
		phi -= Input.GetAxis("Mouse X") * phiAxisSpeed;

		theta = ClampTheta(theta, thethaMin, thethaMax);
		phi = ClampPhi(phi);
	}

	void RefreshTransform()
	{
		transform.position = HeilSphericalCoordinateSystem(theta, phi, r) + target.position;
		transform.rotation = Quaternion.LookRotation(target.position - transform.position);
	}

	public static Vector3 HeilSphericalCoordinateSystem(float Theta, float Phi, float r)
	{
		Theta *= Mathf.Deg2Rad;
		Phi *= Mathf.Deg2Rad;
		float x = r * Mathf.Sin(Theta) * Mathf.Cos(Phi);
		float z = r * Mathf.Sin(Theta) * Mathf.Sin(Phi);
		float y = r * Mathf.Cos(Theta);

		return new Vector3(x, y, z);
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
