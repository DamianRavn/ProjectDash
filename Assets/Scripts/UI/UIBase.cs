using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class UIBase : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public virtual void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public virtual void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        print("quiting");
        Application.Quit();
    }
}
