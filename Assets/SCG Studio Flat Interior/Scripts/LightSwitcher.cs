using UnityEngine;
using System.Collections;

//This script is switching between day and night lightning in the scene, when you hit TAB

public class LightSwitcher : MonoBehaviour {

	public GameObject[] emissiveObjectsToSwitch;

	GameObject[] sceneLights; 		//Add here all interior lights, that need to be switched.
	GameObject sceneSun;			//Add here sun.
	ReflectionProbe[] sceneProbes;	//List of all reflection probes;


	Quaternion sunDayTransform;
	Quaternion sunNightTransform;
	bool isDay = true;
	
	void Start () 
	{
		sceneLights = GameObject.FindGameObjectsWithTag ("Light");
		sceneSun = GameObject.FindGameObjectWithTag ("Sun");
		sceneProbes = GameObject.FindObjectsOfType<ReflectionProbe>();
		sunDayTransform = sceneSun.transform.rotation;
		sunNightTransform = Quaternion.Euler (new Vector3 (-25.0f, 17.5f, 0.5f));

		for (int i = 0; i < sceneLights.Length; i++)
		{
			sceneLights[i].GetComponent<Light>().enabled = false;
		}
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Tab))
		{
			isDay = !isDay;

			for (int i = 0; i < sceneLights.Length; i++)
			{
				sceneLights[i].GetComponent<Light>().enabled = !sceneLights[i].GetComponent<Light>().isActiveAndEnabled;
			}

			foreach (ReflectionProbe probe in sceneProbes)
			{
				probe.RenderProbe();
			}

			sceneSun.GetComponent<Light>().enabled = !sceneSun.GetComponent<Light>().isActiveAndEnabled;

			if (isDay)
			{
				sceneSun.transform.rotation = sunDayTransform;

				foreach (GameObject obj in emissiveObjectsToSwitch)
				{
					obj.GetComponent<Renderer>().material.SetFloat ("_EmissivePower", 0.0f);
				}
			}
			else
			{
				foreach (GameObject obj in emissiveObjectsToSwitch)
				{
					obj.GetComponent<Renderer>().material.SetFloat  ("_EmissivePower", 1.5f);
				}
				sceneSun.transform.rotation = sunNightTransform;
			}
			DynamicGI.UpdateEnvironment();

		}
	}
}
