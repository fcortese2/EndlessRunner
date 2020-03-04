using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUIScript : MonoBehaviour
{
    private float currentTimeLapse = 0f;
    void Update()
    {
        currentTimeLapse += Time.deltaTime;
        int minutes = (int)(currentTimeLapse / 60);

        int seconds = (int)(currentTimeLapse - (minutes * 60));

        GetComponent<Text>().text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }
}
