using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public bool key = false;

    public GameObject keyIcon;
    public GameObject flashlightObj;
    public bool flashlight = true;
    public KeyCode input;
	
	// Update is called once per frame
	void Update () {

        if (key)
            keyIcon.SetActive(true);
        else
            keyIcon.SetActive(false);

        if (Input.GetKeyDown(input))
        {

            if (flashlight)
            {

                flashlightObj.SetActive(false);
                flashlight = false;

            }

            else
            {

                flashlightObj.SetActive(true);
                flashlight = true;

            }
                

        }

	}
}
