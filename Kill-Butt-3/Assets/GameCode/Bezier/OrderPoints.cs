using UnityEngine;

class OrderPoints
{
	public static Vector3[] BuildRandomized(Curve curve)
	{
		int OPsN = curve.orderPointsAmount;
		int ord = curve.order;
		Vector3 random = curve.randomizeVector;
		float maxR = curve.maxRadius;
		Vector3[] OPs = new Vector3[OPsN + 1];
		int scN = OPsN / ord + (OPsN % ord != 0 ? 1 : 0);

		for(int i = 0; i <= OPsN; i++)
		{
			//float randomForX;

			//if(i == 0 || i == OPsN)
			//{
			//	randomForX = 0;
			//}
			//else
			//{
			//	randomForX = Random.Range(-0.3f, 0.3f) * random.x;
			//}

			float randomForY = Random.Range(-1.0f, 1.0f) * random.y;
			float randomForZ = Random.Range(-1.0f, 1.0f) * random.z;

			//Vector3[] scInfo = GetOrderPointInfo(i, OPsN, controlPoints);
			//Vector3 notRandomized = scInfo[0];
			//Vector3 frwd = scInfo[1].normalized;
			Vector3 frwd = Vector3.forward;
			Vector3 rgt = Vector3.right;
			Vector3 up = Vector3.up;

			Vector3 Rx = rgt * i;
			Vector3 Ry = up * randomForY * maxR;
			Vector3 Rz = frwd * randomForZ * maxR;

			if(i % ord == 1 && i > ord)
			{
				OPs[i] = ConnectSubcurves(OPs[i - 2], OPs[i - 1], Rx.x);
			}
			else
			{
				OPs[i] = Rx + Ry + Rz;
			}
		}

		return OPs;
	}

	static Vector3 ConnectSubcurves(Vector3 A, Vector3 B, float Cx)    //уравнение прямой
	{
		float X = (Cx - A.x) / (B.x - A.x);
		float y = X * (B.y - A.y) + A.y;
		float z = X * (B.z - A.z) + A.z;
		Vector3 C = new Vector3(Cx, y, z);

		return C;
	}

	static Vector3[] GetOrderPointInfo(int iOrder, int orderPN, Vector3[] cFn)
	{
		float totalL = Mathf.Sqrt(GetSqrLenght(cFn, cFn.Length));
		float iOrderL = iOrder / orderPN * totalL;

		for(int i = 0; i < cFn.Length - 1; i++)
		{
			float iControlL = GetSqrLenght(cFn, i);

			if(iOrderL > iControlL)
			{
				float delta = Mathf.Sqrt(iOrderL - iControlL);
				Vector3 p = Vector3.ClampMagnitude(cFn[i + 1] - cFn[i], delta) + cFn[i];
				return new Vector3[2] { p, cFn[i + 1] };
			}
		}

		return null;
	}

	static float GetSqrLenght(Vector3[] ps, int iMax)
	{
		float l = 0;

		for(int i = 1; i < iMax; i++)
		{
			l += Vector3.SqrMagnitude(ps[1] - ps[0]);
		}

		return l;
	}
}