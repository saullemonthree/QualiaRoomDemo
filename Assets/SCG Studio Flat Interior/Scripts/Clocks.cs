using UnityEngine;
using System.Collections;

public class Clocks : MonoBehaviour 
{
	public GameObject hourPointer;
	public GameObject minutePointer;

	private Vector3 hourPointerRotation;
	private Vector3 minutePointerRotation;
	float tempHours;

	void Update () 
	{
		if (System.DateTime.Now.Hour >= 12.0f) tempHours = System.DateTime.Now.Hour - 12.0f;

		float tempFloatOne = Mathf.Lerp(0.0f, 360.0f, (tempHours / 12.0f) + (System.DateTime.Now.Minute / 1800.0f));
		hourPointerRotation = new Vector3 (0.0f, 0.0f, tempFloatOne);
		hourPointer.transform.localRotation = Quaternion.Euler (hourPointerRotation);

		minutePointerRotation = new Vector3 (0.0f, 0.0f, Mathf.Lerp(0.0f, 360.0f, System.DateTime.Now.Minute / 60.0f));
		minutePointer.transform.localRotation = Quaternion.Euler (minutePointerRotation);
	}
}
