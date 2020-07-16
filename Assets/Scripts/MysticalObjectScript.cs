using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    //public AudioClip SoundToPlay;
    //private float Volume = 1;
    //AudioSource audio;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            Debug.Log("Hoho so you've finally managed to solve the riddle!");
            //audio.PlayOneShot(SoundToPlay, Volume);
            //safe.ButtonPressed(value);
        }

        else if (c.tag == "Wizard")
        {
            Debug.Log("Roll the credits!");
        }
    }
}
