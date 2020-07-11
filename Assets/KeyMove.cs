using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour
{
   public float speed = 0.9f;

	// Calls while key is in trigger
    void OnTriggerStay (Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.VelocityChange);
    }

}
