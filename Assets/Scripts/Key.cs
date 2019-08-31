using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

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
        
        if (other.CompareTag("Player") && lookingAt)
        {

            if (Input.GetKeyDown(input))
            {

                Inventory inv = other.GetComponent<Inventory>();
                inv.key = true;

                objManager.objIndex++;

                Destroy(gameObject);

            }
            
        }

    }

}
