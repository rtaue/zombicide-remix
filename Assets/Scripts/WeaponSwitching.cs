using UnityEngine;
using UnityEditor.UI;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon = 0;

    public Animator anim;

	// Use this for initialization
	void Start () {

        SelectWeapon();

	}
	
	// Update is called once per frame
	void Update () {

        int previousSelectedWeapon = selectedWeapon;
		
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {

            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else 
                selectedWeapon++;

            anim.SetTrigger("isOpening");

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {

            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;

            anim.SetTrigger("isOpening");

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            selectedWeapon = 0;

            anim.SetTrigger("isOpening");

        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {

            selectedWeapon = 1;

            anim.SetTrigger("isOpening");

        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {

            selectedWeapon = 2;

            anim.SetTrigger("isOpening");

        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {

            selectedWeapon = 3;

            anim.SetTrigger("isOpening");

        }

        if (previousSelectedWeapon != selectedWeapon)
        {

            SelectWeapon();

        }

    }

    public void SelectWeapon()
    {

        int i = 0;
        foreach(Transform weapon in transform)
        {

            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;

        }

    }
}
