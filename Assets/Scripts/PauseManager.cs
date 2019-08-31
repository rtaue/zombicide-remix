using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject mapMenuUI;
    public GameObject objMenuUI;
    public GameObject optMenuUI;
    public Animator fadeAnim;
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isGamePaused)
                Resume();
            else
                Pause();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {

            if (isGamePaused)
            {

                if (!mapMenuUI.activeSelf)
                    Map();
                else
                    Resume();

            }
            else
            {

                Map();
                Pause();

            }

        }

        if (Input.GetKeyDown(KeyCode.O))
        {

            if (isGamePaused)
            {

                if (!objMenuUI.activeSelf)
                    Objective();
                else
                    Resume();

            }
            else
            {

                Objective();
                Pause();

            }

        }

    }

    void Pause()
    {

        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isGamePaused = true;
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void Resume()
    {

        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void LoadScene(string sceneToGo)
    {

        Time.timeScale = 1f;
        fadeAnim.SetTrigger("toFade");
        MainData.nextScene = sceneToGo;
        Invoke("DelayLoad", 1f);

    }

    void DelayLoad()
    {

        SceneManager.LoadScene("Loading");

    }

    void Map()
    {

        mapMenuUI.SetActive(true);
        objMenuUI.SetActive(false);
        optMenuUI.SetActive(false);

    }

    void Objective()
    {

        mapMenuUI.SetActive(false);
        objMenuUI.SetActive(true);
        optMenuUI.SetActive(false);

    }

    public void Quit()
    {

        Application.Quit();

    }

}
