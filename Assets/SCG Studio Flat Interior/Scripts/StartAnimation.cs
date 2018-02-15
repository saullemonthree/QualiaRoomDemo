using UnityEngine;
using System.Collections;

public class StartAnimation : MonoBehaviour 
{
	public Animator animatedCamera;				//Place camera with animator here
	// Use this for initialization

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			animatedCamera.Play("Canim_01");
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			animatedCamera.Play("Canim_02");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			animatedCamera.Play("Canim_03");
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			animatedCamera.Play("Canim_04");
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			animatedCamera.Play("Canim_05");
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			animatedCamera.Play("Canim_06");
		}
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			animatedCamera.Play("Canim_07");
		}
		if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			animatedCamera.Play("Canim_08");
		}
	}
}
