using UnityEngine;

public class Tutorial : MonoBehaviour {

    private void Start()
    {

        Invoke("Pause", 1.5f);

    }

    public void StartGame()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;

    }void Pause()
    {

        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;

    }



}
