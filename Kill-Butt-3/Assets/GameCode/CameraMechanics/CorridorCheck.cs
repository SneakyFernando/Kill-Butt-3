//using UnityEngine;
//using System.Collections.Generic;
//using System.Collections;

//class CorridorCheck : MonoBehaviour
//	{
//	public static Vector3[] centerCurve;
//	static float t = 0;
//	public static Transform trans;

//	private void Start()
//	{
//		trans = transform;
//	}

//	public static IEnumerator MoveAlongCurve()
//	{
//		int i = centerCurve.Length-1;

//		while(i != 1)
//			{
//			t += Time.deltaTime;
//			trans.position = Vector3.Lerp(centerCurve[i], centerCurve[i-1], t);
//			trans.rotation = Quaternion.LookRotation(-centerCurve[i] + centerCurve[i - 1]);

//			if(t>1)
//			{
//				t /= 1;
//				i--;
//			}

//			yield return null;
//		}
//	}
//}