using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshopCrate : MonoBehaviour {

    public KeyCode input;

    public bool lookingAt = false;

    public ObjectiveManager objManager;

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

        if (other.CompareTag("Player") && lookingAt && Input.GetKeyDown(input))
        {

                objManager.objIndex++;

                Destroy(gameObject);

        }

    }

}
