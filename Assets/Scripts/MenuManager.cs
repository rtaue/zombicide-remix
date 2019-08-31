using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Animator fadeAnim;

    public float timeToWait = 1f;

    public void LoadScene(string sceneToGo)
    {

        MainData.nextScene = sceneToGo;
        Invoke("DelayLoad", timeToWait);

    }

    public void LoadSceneFast(string sceneToGo)
    {

        MainData.nextScene = sceneToGo;
        SceneManager.LoadScene("Loading");

    }

    void DelayLoad()
    {

        SceneManager.LoadScene("Loading");

    }

    public void FadeTrigger()
    {

        fadeAnim.SetTrigger("toFade");

    }

    public void Quit()
    {

        Application.Quit();

    }

}
