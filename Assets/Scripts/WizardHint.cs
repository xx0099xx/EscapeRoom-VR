using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardHint : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter()
    {
        if (!alreadyPlayed) // && c.tag == "player")
        {
            audio.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
        }
    }

}
