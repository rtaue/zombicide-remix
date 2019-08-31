using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour {

    public KeyCode input;

    public bool lookingAt = false;
    public Gun[] weapons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReplenishAmmo()
    {

        for(int i = 0; i < weapons.Length; i++)
        {

            weapons[i].maxAmmo = weapons[i].maxAmmoCapacity;

        }

    }

    private void OnMouseOver()
    {

        lookingAt = true;

    }

    private void OnMouseExit()
    {

        lookingAt = false;

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && Input.GetKeyDown(input)&& lookingAt)
        {

            ReplenishAmmo();

        }

    }
}
