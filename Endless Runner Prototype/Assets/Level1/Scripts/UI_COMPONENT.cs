using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_COMPONENT : MonoBehaviour
{
    
    public void PauseGame()
    {
        Time.timeScale = 0.00001f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
