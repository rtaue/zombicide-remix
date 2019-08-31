using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour {

    public WeaponSwitching wpS;
    public GameObject ammo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (wpS.selectedWeapon == 0)
        {

            ammo.SetActive(false);

        }
        else
        {

            ammo.SetActive(true);

        }

	}
}
