using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class GameController : MonoBehaviour
{
	public static List<Unit> units = new List<Unit>();

	private void Start()
	{
		MeshManipulator.redSinkOn = Resources.Load("Materials/redSinkOn") as Material;
		MeshManipulator.redSinkOff = Resources.Load("Materials/redSinkOff") as Material;
		MeshManipulator.blueSinkOn = Resources.Load("Materials/blueSinkOn") as Material;
		MeshManipulator.blueSinkOff = Resources.Load("Materials/blueSinkOff") as Material;
	}

	public static void ExitGame()
	{
		SceneManager.LoadSceneAsync(0);

	}
}
