using UnityEngine;
using System;

public class PointsFiller
{
	public static Vector3[] Fill(Vector3[] OPs, int ord, int PsN)
	{
		int OPsN = OPs.Length - 1;
		Vector3[] Ps = new Vector3[PsN + 1];

		int scN = OPsN / ord + (OPsN % ord != 0 ? 1 : 0);

		for(int P = 0; P <= PsN; P++)
		{
			float PsD = (float)PsN / OPsN;
			float scP = P / (PsD * ord);
			scP += scP % 1 == 0 && scP > 0 ? -1 : 0;
			int sci = Mathf.FloorToInt(scP);

			int scOP0 = sci * ord;
			int scOP1 = (sci + 1) == scN ? OPsN : (sci + 1) * ord;
			int scOPsN = scOP1 - scOP0;
			double scOPsD = PsD * scOPsN;

			double PL = P - scOP0 * PsD;
			double t = PL / scOPsD;

			Vector3[] scPs = new Vector3[scOPsN + 1];

			for(int i = 0; i < scPs.Length; i++)
			{
				scPs[i] = OPs[sci * ord + i];
			}

			Ps[P] = CoreEquation(scPs, t);
		}

		return Ps;
	}

	static Vector3 CoreEquation(Vector3[] Ps, double t)
	{
		Vector3 P = Vector3.zero;
		int n = Ps.Length - 1;

		for(int k = 0; k <= n; k++)
		{
			int binomalK = Factorial(n) / (Factorial(k) * Factorial(n - k));
			double polynomial = binomalK * Math.Pow(t, k) * Math.Pow((1 - t), n - k);
			P += (float)polynomial * Ps[k];
		}

		return P;
	}

	static int Factorial(int value)
	{
		int factorial = 1;

		for(int i = 1; i <= value; i++)
		{
			factorial *= i;
		}

		return factorial;
	}
}