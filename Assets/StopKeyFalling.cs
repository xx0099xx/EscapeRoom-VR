using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopKeyFalling : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		// Exists solely to stop the key for falling into the ground and out of bounds
        if (transform.position.y <= 0.0f)
		{
			transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
			Debug.Log("Stopped the key from falling out of bounds.");
		}
    }
}
