using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public AudioSource audS;
    public AudioClip[] audC;

    public Animator anim;

    public KeyCode input;
    public bool isLocked = false;
    public bool needKey = false;
    [SerializeField]
    bool isOpen = false;

    public GameObject doorTextObj;
    public Text doorText;

    void OpenDoor()
    {

        
        anim.SetBool("isOpening", true);
        isOpen = true;
        audS.clip = audC[0];
        audS.Play();

    }

    void CloseDoor()
    {

        
        anim.SetBool("isOpening", false);
        isOpen = false;
        audS.clip = audC[0];
        audS.Play();

    }

    void DoorLocked()
    {

        
        anim.SetTrigger("locked");
        audS.clip = audC[1];
        audS.Play();

    }

    void UnlockDoor()
    {

        audS.clip = audC[2];
        audS.Play();
        isLocked = false;

    }
    /*
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(input))
        {

            if (isLocked && needKey)
            {

                Inventory inv = other.transform.GetComponent<Inventory>();
                if (inv != null)
                {

                    if (inv.key)
                    {

                        doorTextObj.SetActive(false);
                        UnlockDoor();
                    }
                        
                    else
                    {

                        doorText.text = "You need a key.";
                        doorTextObj.SetActive(true);
                        DoorLocked();

                    } 

                }

                return;

            }
            else if (isLocked)
            {

                WeaponSwitching wpSwitch = other.GetComponentInChildren<WeaponSwitching>();
                if (wpSwitch != null)
                {

                    if (wpSwitch.selectedWeapon == 0)
                    {

                        doorTextObj.SetActive(false);
                        UnlockDoor();
                    }
                        
                    else
                    {

                        doorText.text = "Door is locked or jammed. Try using a crowbar.";
                        doorTextObj.SetActive(true);
                        DoorLocked();

                    } 

                }
                
                return;

            }

            if (isOpen)
            {

                CloseDoor();

            }
            else OpenDoor();

        }

    }
    */

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(input))
        {

            if (isLocked)
            {

                if (needKey)
                {
                    Inventory inv = other.transform.GetComponent<Inventory>();
                    if (inv != null)
                    {

                        if (inv.key)
                        {

                            doorTextObj.SetActive(false);
                            UnlockDoor();
                        }

                        else
                        {

                            doorText.text = "You need a key.";
                            doorTextObj.SetActive(true);
                            DoorLocked();

                        }

                    }
                    return;
                }
                else
                {
                    WeaponSwitching wpSwitch = other.GetComponentInChildren<WeaponSwitching>();
                    if (wpSwitch != null)
                    {

                        if (wpSwitch.selectedWeapon == 0)
                        {

                            doorTextObj.SetActive(false);
                            UnlockDoor();
                        }

                        else
                        {

                            doorText.text = "Door is locked or jammed. Try using a crowbar.";
                            doorTextObj.SetActive(true);
                            DoorLocked();

                        }

                    }
                    
                    return;
                }
               
 
            }
            else if (isOpen)
            {

                CloseDoor();

            }
            else OpenDoor();

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
            doorTextObj.SetActive(false);

    }
}
