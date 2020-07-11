using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public AudioClip sfx;
    public AudioSource sfxSource;

    public float speed = 100f;
	public int valveValue = 0;
	public bool isOn = false;
	public int rotateCount = 0;

	public float lastAngle = 0.0f;

	int maxRotations = 2;

    public bool canRotate = false;
    public GameObject handobj;

    bool canGetCoords = true;
    public float startX;
    public float startY;
    public float oldX;
    public float oldY;
    public float newX;
    public float newY;

    public bool clockwise = true;
    bool playsfx = true;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the original angle value
        lastAngle = transform.eulerAngles.x;

        // By default, tracks right hand, but can be changed to left if it is used instead
        handobj = GameObject.Find("RightHand");
    }

    // Update is called once per frame
    void Update()
    {
	     //Press the space bar to apply no locking to the Cursor
        if (Input.GetKey(KeyCode.Space))
            Cursor.lockState = CursorLockMode.None;

        if(canRotate)
        {
            if(playsfx)
            {
                sfxSource.Play();
                playsfx = false;
            }

            // One-time check to obtain the initial starting point for the coordinates
            if(canGetCoords)
            {
                startX = handobj.transform.position.x;
                startY = handobj.transform.position.y;
                canGetCoords = false;

                oldX = startX;
                oldY = startY;
            }
            
            newX = handobj.transform.position.x;
            newY = handobj.transform.position.y;

            float xDif = newX - oldX / newX + oldX;
            float yDif = newY - oldY / newY + oldY;

            if (newY >= oldY)
            {
                if(oldX < startX)
                {
                    clockwise = true;
                }
                else
                {
                    clockwise = false;
                }
            }

            else
            {
                if (oldX >= startX)
                {
                    clockwise = true;
                }
                else
                {
                    clockwise = false;
                }
            }

            float angle = Mathf.Sqrt((xDif * xDif) + (yDif * yDif)) * speed * Mathf.Deg2Rad;

            if (!clockwise)
            {
                angle = -angle;
            }

            print(newX);
            print(newY);
            print(angle);

            float currentAngle = lastAngle + angle;

            if (currentAngle >= -10.0f && currentAngle <= (maxRotations * 360.0f + 10.0f))
            {
                lastAngle = currentAngle;

                //Cursor.lockState = CursorLockMode.Locked;

                transform.Rotate(0, -angle, 0, Space.Self);

                rotateCount = (int)((lastAngle + 10.0f) / 360);

                // Switches valves on/off once sufficient rotations have bee
                if (rotateCount >= maxRotations)
                {
                    isOn = true;
                }

                if (rotateCount <= 0)
                {
                    isOn = false;
                }

            }

            oldX = newX;
            oldY = newY;

        }

        else
        {
            sfxSource.Stop();
            playsfx = true;
        }
    }

    // Debugging code from before moving to VR - to make sure that the room's logic worked 
	/*void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;
		float rotZ = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;

		float currentAngle = lastAngle + rotX;

		if (currentAngle >= -10.0f && currentAngle <= (maxRotations * 360.0f + 90.0f))
		{
			lastAngle = currentAngle;

			//Cursor.lockState = CursorLockMode.Locked;

			transform.Rotate(0, -rotX, 0, Space.Self);

			rotateCount = (int) ((lastAngle + 10.0f) / 360);

            // Switches valves on/off once sufficient rotations have bee
			if(rotateCount >= maxRotations)
			{
				isOn = true;
			}

			if(rotateCount <= 0)
			{
				isOn = false;
			}

		}

	}*/
}
