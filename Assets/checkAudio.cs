using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAudio : MonoBehaviour
{
    public UnityEngine.AudioSource audioSource;
    public GameObject portal;
    public Teleport teleportation;
    //public Script teleportation;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("test");
        //Component[] x = portal.GetComponents(typeof(Component));
        //foreach (Component c in x)
        //{
        //    Debug.Log(c);
        //}
        audioSource = portal.GetComponent<UnityEngine.AudioSource>();
        teleportation = portal.GetComponent<Teleport>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            teleportation.solved = true;
        }
    }
}
