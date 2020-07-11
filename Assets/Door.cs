using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool isUnlocked = false;
    public int counter = 0;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnlocked)
        {
            // Creates a 2 second time delay before the door opens
            if(timer < 2.0f)
            {
                timer += Time.deltaTime;
            }
        }

        if (timer >= 2.0f && counter < 90)
        {
            transform.Rotate(0, 1, 0);
            counter++;
        }
    }
}
