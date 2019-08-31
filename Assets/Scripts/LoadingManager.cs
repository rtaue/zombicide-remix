using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour {

    public Image background;
    public Sprite[] zombicideCovers;
    public Slider slider;
    public Animator fadeAnim;

    // Use this for initialization
    void Start () {

        int i;
        i = Random.Range(0, zombicideCovers.Length);
        background.sprite = zombicideCovers[i];

        StartCoroutine(LoadAsynchronously(MainData.nextScene));

	}

    IEnumerator LoadAsynchronously (string nextScene)
    {

        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(nextScene);

        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {

            float progess = Mathf.Clamp01(ao.progress / 0.9f);

            slider.value = progess;

            if (ao.progress == 0.9f)
            {

                fadeAnim.SetTrigger("toFade");

                ao.allowSceneActivation = true;

            }

            yield return null;

        }

    }
}
