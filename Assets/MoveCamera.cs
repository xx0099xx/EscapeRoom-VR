using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float xAxisValue = Input.GetAxis("Horizontal");
		 float zAxisValue = Input.GetAxis("Vertical");
		 if(Camera.current != null)
		 {
			 Camera.current.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));
		 }
		 
		 if (Input.GetKey("q"))
         {
            transform.Rotate(0, -1, 0, Space.Self);
         }

		 if (Input.GetKey("e"))
         {
            transform.Rotate(0, 1, 0, Space.Self);
         }

		 if (Input.GetKey("o"))
         {
            transform.Rotate(-1, 0, 0, Space.Self);
         }

		 if (Input.GetKey("p"))
         {
            transform.Rotate(1, 0, 0, Space.Self);
         }
    }
}
