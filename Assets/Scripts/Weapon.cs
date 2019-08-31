using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public KeyCode input;
    public bool lookingAt = false;

    public GameObject newParent;
    public GameObject newChild;

    public WeaponSwitching wpS;

    public GameObject wpBarImg;

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

            newChild.transform.SetParent(newParent.transform);
            newChild.transform.SetAsLastSibling();

            wpS.selectedWeapon = newChild.transform.GetSiblingIndex();
            wpS.SelectWeapon();

            wpBarImg.SetActive(true);

            Destroy(gameObject);

        }

    }
}
