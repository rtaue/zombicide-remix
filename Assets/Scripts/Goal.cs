using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public ObjectiveManager objManager;
    public Animator fadeAnim;
    public GameObject text;
    public string nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadScene(string sceneToGo)
    {

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        MainData.nextScene = sceneToGo;
        Invoke("DelayLoad", 1f);

    }

    void DelayLoad()
    {

        SceneManager.LoadScene("Loading");

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {

            if (objManager.objIndex > 1)
            {

                fadeAnim.SetTrigger("toFade");
                LoadScene(nextScene);

            }
            else
            {

                text.SetActive(true);

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
            text.SetActive(false);

    }

}
