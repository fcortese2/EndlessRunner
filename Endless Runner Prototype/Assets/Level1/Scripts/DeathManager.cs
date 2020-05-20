using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public Text deathdisp;
    public string mainMenuScene;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            Time.timeScale = 0.0001f;
            deathdisp.GetComponent<Text>().enabled = true;
            deathdisp.text = "Score: " + GameObject.FindGameObjectWithTag("GM").GetComponent<GM_MANAGER>().score;
            //End of run code here...

            AudioManager tempRef = GameObject.FindGameObjectWithTag("GM").GetComponent<AudioManager>();
            tempRef.ToggleGameMusic(false);

            SceneManager.LoadSceneAsync(mainMenuScene);
            
        }
    }


}
