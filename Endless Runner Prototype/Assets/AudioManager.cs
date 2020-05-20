using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource PauseSource;

    private AudioClip musicClip;
    private PlayerMovement playercontroller;
    private void Start()
    {
        musicClip = MusicSource.clip;
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playercontroller.ChangeSpeed(playercontroller.Speed / 2);
    }

    private bool step1 = false;
    private bool step2 = false;
    private bool step3 = false;
    private bool step4 = false;
    private bool step5 = false;
    private bool step6 = false;
    private void Update()
    {
        if (MusicSource.time>9.8 && MusicSource.time<10.2 && step1 == false)
        {
            step1 = true;
            Debug.Log("10 sec in" + MusicSource.time);
            playercontroller.ChangeSpeed(playercontroller.Speed * 2);
        }
        else if (MusicSource.time > 24.8 && MusicSource.time < 25.2 && step2 == false)
        {
            step2 = true;
            playercontroller.ChangeSpeed(playercontroller.Speed + 20);
        }
        else if (MusicSource.time > 88.2 && MusicSource.time < 88.6 && step3 == false)
        {
            step3 = true;
            playercontroller.ChangeSpeed((playercontroller.Speed - 20) / 2);
        }
        else if (MusicSource.time > 97.9 && MusicSource.time < 98.2 && step4 == false)
        {
            step4 = true;
            playercontroller.ChangeSpeed(playercontroller.Speed + 10);
        }
        else if (MusicSource.time > 102.9 && MusicSource.time < 103.2 && step5 == false)
        {
            step5 = true;
            playercontroller.ChangeSpeed(playercontroller.Speed + 10);
        }
        else if (MusicSource.time > 107.9 && MusicSource.time < 108.2 && step6 == false)
        {
            step6 = true;
            playercontroller.ChangeSpeed(65);
        }
    }

    public void ToggleGameMusic(bool value)
    {
        if (value == false)
        {
            MusicSource.Pause();
        }
        else if (value == true)
        {
            MusicSource.Play();
        }
        
    }
    public void TogglePauseMusic(bool value)
    {
        if (value == false)
        {
            PauseSource.Pause();
        }
        else if (value == true)
        {
            PauseSource.time = 0;
            PauseSource.Play();
        }
    }
}
