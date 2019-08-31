using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour {

    public int damage = 20;
    public float range = 20f;

    public Animator anim;
    public Camera fpsCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetButton("Fire1"))
        {

            anim.SetTrigger("attack");

            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                ZombieController zCtrl = hit.transform.GetComponentInParent<ZombieController>();
                if (zCtrl != null)
                    zCtrl.TakeDamage(damage);

            }

        }


	}

}
