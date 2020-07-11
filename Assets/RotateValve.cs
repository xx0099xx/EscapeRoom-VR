using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateValve : MonoBehaviour
{
    public int rotateState = 0; // rotateState = 0 means it will rotate clockwise, = 1 means anticlockwise
	public float accel = 30;

	// Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				if (hit.transform != null)
				{
					Rigidbody rb;

					if (rb = hit.transform.GetComponent<Rigidbody>())
					{
						PrintName(hit.transform.gameObject);
						Rotate(hit.transform.gameObject);
					}
				}
			}
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			rotateState = 1 - rotateState;
			Debug.Log("Stopped rotating.");
			accel = 30;
		}
	}

	private void PrintName(GameObject go)
	{
		print(go.name);
	}

	private void Rotate(GameObject go)
	{
		if (rotateState == 0)
		{
			this.transform.Rotate(0,accel/60,0);
			//Debug.Log("Rotating: " + this.transform.rotation.y);
			if (accel < 120)
			{
				accel++;				
			}

		}

		else
		{
			this.transform.Rotate(0,-(accel/60),0);
			//Debug.Log("Rotating: " + this.transform.rotation.y);
			if (accel < 120)
			{
				accel++;				
			}
		}
	}
		
		/*if (Input.GetKey(KeyCode.Mouse0))
		{
			if (rotateState == 0)
			{
				this.transform.Rotate(0,accel/60,0);
				//Debug.Log("Rotating: " + this.transform.rotation.y);
				if (accel < 120)
				{
					accel++;				
				}

			}

			else
			{
				this.transform.Rotate(0,-(accel/60),0);
				//Debug.Log("Rotating: " + this.transform.rotation.y);
				if (accel < 120)
				{
					accel++;				
				}
			}
		}
		
		if (Input.GetMouseButtonUp(0))
		{
			rotateState = 1 - rotateState;
			Debug.Log("Stopped rotating.");
			accel = 30;
		}
		*/
}
