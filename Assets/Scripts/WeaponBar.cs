using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBar : MonoBehaviour {

    public WeaponSwitching wpS;

    public GameObject[] selectedBorder = new GameObject[3];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (wpS.selectedWeapon == 0)
        {

            selectedBorder[0].SetActive(true);
            selectedBorder[1].SetActive(false);
            selectedBorder[2].SetActive(false);

        }
        else if (wpS.selectedWeapon == 1)
        {

            selectedBorder[1].SetActive(true);
            selectedBorder[2].SetActive(false);
            selectedBorder[0].SetActive(false);

        }
        else if (wpS.selectedWeapon == 2)
        {

            selectedBorder[2].SetActive(true);
            selectedBorder[0].SetActive(false);
            selectedBorder[1].SetActive(false);

        }


    }
}
