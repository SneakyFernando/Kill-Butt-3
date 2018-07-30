using UnityEngine;

class OrderPoints
{
	public static Vector3[] GetPointsForConnection(Connection connection, Vector2 size)
	{
		Node A = connection.fromNeuron.node;
		Node B = connection.toNeuron.node;
		Transform aDoor = connection.fromDoor.structure.t;
		Transform bDoor = connection.toDoor.structure.t;
		float d = Sizes.BuildingParameters.d;
		
		Vector3[] mainPs = new Vector3[4];
		mainPs[0] = DoorHelper.A(connection.fromDoor,size) + aDoor.right * d * (.0f + 1)/* - aDoor.forward * d * .1f*/ - aDoor.up * 1f * d;//ugly hack for door to corridor aligning
		mainPs[3] = DoorHelper.B(connection.toDoor, size) - bDoor.right * d * (.0f + 1f) /*- bDoor.forward * d * .1f*/ - bDoor.up * 1f * d;

		//float yDeltaDistr = B.yDistribution - A.yDistribution;
		//float yM = yDeltaDistr * Map.C;

		float yDeltaDistr = B.yDistribution - A.yDistribution;
		float yRadians =  yDeltaDistr*Mathf.PI/2;
		float n = 2*Mathf.PI / yRadians;
		float l =( (float)4 / 3) * Mathf.Tan(Mathf.PI / (2 * n)) * Map.R;

		//mainPs[1] = mainPs[0] + aDoor.forward * (Sizes.Map.entrConnectionL + yM / 3);
		//mainPs[2] = mainPs[3] + bDoor.forward * (Sizes.Map.entrConnectionL + yM / 3);
		mainPs[1] = mainPs[0] + aDoor.forward * l;
		mainPs[2] = mainPs[3] + bDoor.forward * l;

		return mainPs;
	}

	public static Vector3[][] GetAligningPoints(Connection connection)
	{
		Vector3[][] aligningPs = new Vector3[2][];
		aligningPs[0] = new Vector3[4];
		aligningPs[1] = new Vector3[4];

		Vector3 A = DoorHelper.A(connection.fromDoor);

		aligningPs[0][0] = Vector3.zero;
		aligningPs[0][1] = DoorHelper.B(connection.fromDoor) - A;
		aligningPs[0][2] = DoorHelper.C(connection.fromDoor) - A;
		aligningPs[0][3] = DoorHelper.D(connection.fromDoor) - A;

		A = DoorHelper.B(connection.toDoor);
		aligningPs[1][0] = Vector3.zero;
		aligningPs[1][1] = DoorHelper.A(connection.toDoor) - A;
		aligningPs[1][2] = DoorHelper.D(connection.toDoor) - A;
		aligningPs[1][3] = DoorHelper.C(connection.toDoor) - A;

		return aligningPs;
	}

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