using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject head;
    public string nextRoom;
    public bool solved = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (solved && other.gameObject == head)
        {
            Valve.VR.SteamVR_LoadLevel.Begin(nextRoom);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject);
    //}
}
