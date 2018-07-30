using UnityEngine;
using CameraRotationSystem;

enum CameraStance
{
	InnerSystem,
	OuterSpace
}

class CameraBehaviour : MonoBehaviour
{
	private void Awake()
	{
		Interface.camera = GetComponent<Camera>();
		Interface.transform = transform;
	}

	private void Start()
	{
		Observer.freecore = new GameObject("Free Core").transform;
	}

	private void LateUpdate()
	{
		if(!Interface.isInterpolating)
		{
			Rotator.RefreshTransform();
		}
	}

	public static void ChangeDistance()
	{
		if(!Interface.isInterpolating && !Interface.camera.orthographic)
		{
			Rotator.InputR();
		}
	}

	public static void ChangeAngle()
	{
		if(!Interface.isInterpolating && !Interface.camera.orthographic)
		{
			Rotator.InputThetaPhi();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.gameObject.layer == LayersData.Room)
		{
			if(!UIController.isIdeaNamesRendering)
			{
				UIController.isIdeaNamesRendering = true;
				UIController.SetNeuronIdeasRender(Detecter.GetRoomByTransform(other.transform).neuron, true);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.layer == LayersData.Room)
		{
			UIController.isIdeaNamesRendering = false;
			UIController.SetNeuronIdeasRender(null, false);
		}
	}
}
