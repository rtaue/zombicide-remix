using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

    public GameObject weaponmesh;
    Vector3 initialposition;
    public AudioSource audSource;
    public AudioClip[] audClip;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 50f;

    public KeyCode reloadKey;
    public int maxAmmoCapacity = 20;
    public int maxAmmo = 20;
    public int maxClipAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Text currentAmmoText;
    public Text maxAmmoText;

    public Animator anim;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    private void Start()
    {

        initialposition = weaponmesh.transform.localPosition;
        currentAmmo = maxClipAmmo;
        maxAmmo = maxAmmoCapacity;

    }

    private void OnEnable()
    {

        isReloading = false;
        anim.SetBool("reloading", false);

    }

    // Update is called once per frame
    void Update () {

        if (isReloading)
            return;

        if ((currentAmmo <= 0 || Input.GetKeyDown(reloadKey)) && maxAmmo > 0)
        {

            StartCoroutine(Reload());
            return;

        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {

            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

            weaponmesh.transform.localPosition =
                initialposition + Vector3.back * 0.1f;

            audSource.pitch = 1f + Random.value * 0.2f;
            audSource.clip = audClip[0];
            audSource.Play();

        }

        weaponmesh.transform.localPosition = Vector3.Lerp(
           weaponmesh.transform.localPosition,
           initialposition, Time.deltaTime * 10);

        Ammo();

	}

    IEnumerator Reload()
    {

        isReloading = true;
        Debug.Log("Reloading...");

        anim.SetBool("reloading", true);
        audSource.pitch = 1f;
        audSource.clip = audClip[1];
        audSource.Play();

        yield return new WaitForSeconds(reloadTime - .25f);

        anim.SetBool("reloading", false);

        yield return new WaitForSeconds(.25f);

        if (currentAmmo == 0)
        {

            if (maxClipAmmo < maxAmmo)
            {


                currentAmmo = maxClipAmmo;
                maxAmmo -= maxClipAmmo;

            }

            else
            {

                currentAmmo = maxAmmo;
                maxAmmo = 0;

            }

        }
        else
        {

            int missingAmmo = maxClipAmmo - currentAmmo;
            currentAmmo += missingAmmo;
            maxAmmo -= missingAmmo;

        }

        isReloading = false;
    }

    void Shoot()
    {

        muzzleFlash.Emit(1);

        currentAmmo--;

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            ZombieController zCtrl = hit.transform.GetComponentInParent<ZombieController>();

            if (zCtrl != null)
                zCtrl.TakeDamage(damage);

            

            if (hit.rigidbody != null)
            {

                hit.rigidbody.AddForce(-hit.normal * impactForce);

            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }

    void Ammo()
    {

        currentAmmoText.text = currentAmmo.ToString();
        maxAmmoText.text = maxAmmo.ToString();

    }

    

    }
