using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public AudioClip sfx;
    public AudioSource sfxSource;

    void Start()
    {
        sfxSource.clip = sfx;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Found something...");
        Debug.Log(other.gameObject.tag);
    }

    // Calls when key first leaves trigger
    void OnTriggerExit (Collider other)
    {
        bool doorunlocked = GameObject.Find("DoorHolder").GetComponent<Door>().isUnlocked;

        if (other.gameObject.CompareTag("Key") && !doorunlocked)
        {
            GameObject.Find("DoorHolder").GetComponent<Door>().isUnlocked = true;
            doorunlocked = true;
            Debug.Log("Door is unlocked!");
            sfxSource.Play();
        }
    }

}
