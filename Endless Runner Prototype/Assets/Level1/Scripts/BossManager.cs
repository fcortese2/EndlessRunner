using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    [SerializeField]private bool bossMode = false;  // make private after debug !!!!
    [SerializeField] private float bossTimeLength;
    [SerializeField] private string nextLevelName;

    [Space]
    [Header("Boss Setup")]
    public int TriggerScore;

    public bool BossMode { get { return bossMode; } set { bossMode = value; } }

    public void ActivateBossMode()
    {
        bossMode = true;
        //from here on, only end-of run code
        ToggleBossMode(true);
    }

    private void ExitBossMode()
    {
        bossMode = false;
        ToggleBossMode(false);
    }

    private void ToggleBossMode(bool value)
    {
        if (value == true)
        {
            Invoke("NowToAsyncLoad",bossTimeLength);
        }
        else
        {
            CancelInvoke("NowToAsyncLoad");
        }
    }

    private float currentTime = 0f;
    private void NowToAsyncLoad()
    {
        try
        {
            if (SceneManager.GetSceneByName(nextLevelName) != null)
            {
                SceneManager.LoadSceneAsync(nextLevelName);
            }
            else
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                return;
            }
        }
        catch (System.Exception)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            return;
        }
        
    }
}
