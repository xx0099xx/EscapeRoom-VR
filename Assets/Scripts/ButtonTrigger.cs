using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public int value;
    public Safe safe;
    public AudioClip SoundToPlay;
    private float Volume = 1;
    public Door door;
    AudioSource audio;
 
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter()
    {
        audio.PlayOneShot(SoundToPlay, Volume);
        safe.ButtonPressed(value);
    }
}
