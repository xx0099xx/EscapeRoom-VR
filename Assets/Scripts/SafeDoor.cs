using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from: https://www.youtube.com/watch?v=YAAG-JczuGY

public class SafeDoor : MonoBehaviour
{
    public Transform toOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OpenDoor() {
        toOpen.Rotate(new Vector3(0, 90, 0), Space.World);
    
        yield return new WaitForSeconds(4);
    }

    //public void OpenDoor()
    //{
        //transform.RotateAround(transform.position, new Vector3(0, 1, 0), 90);
        //transform.Rotate(0, 90, 90, Space.Self);
        //transform.localRotation = Quaternion.Euler(0, 90, 0);
    //    transform.RotateAround(transform.position, Vector3.up, 90);
    //}
}
