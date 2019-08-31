using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour {
	public Light lightPoint;

	// Use this for initialization
	void Start () {

        if (!lightPoint)
		    lightPoint = GetComponent<Light> ();
		SwitchOn ();
	}
	
	void SwitchOn(){
		lightPoint.enabled = true;
		Invoke ("SwitchOff", Random.Range (0.01f, 0.05f));
	}

	void SwitchOff(){
		lightPoint.enabled = false;
		Invoke ("SwitchOn", Random.Range (1f,5));
	}
}
