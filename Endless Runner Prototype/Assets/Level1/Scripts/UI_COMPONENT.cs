using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_COMPONENT : MonoBehaviour
{
    bool paused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                ResumeGame();
            }
            else if (!paused)
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.00001f;
        GetComponent<AudioManager>().ToggleGameMusic(false);
        GetComponent<AudioManager>().TogglePauseMusic(true);
        paused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GetComponent<AudioManager>().ToggleGameMusic(true);
        GetComponent<AudioManager>().TogglePauseMusic(false);
        paused = false;
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        Time.timeScale = 1f;
        Application.LoadLevelAsync(Application.loadedLevel);    //leave this even if obsolete
    }
}
