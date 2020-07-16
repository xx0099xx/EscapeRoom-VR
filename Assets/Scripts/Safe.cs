using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public string cur_input;
    private string pwd = "1"; // Change this
    public SafeDoor safedoor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the input bar

        // Temporary
        // Debug.Log(cur_input);

        // Update texture
    }

    public void ButtonPressed(int input)
    {
        if (input == 10) //You've pressed the clear button
        {
            cur_input = "";
        }

        else if (input == 11) //You've pressed enter
        {
            if (string.Equals(cur_input, pwd))
            {
                //Debug.Log("Open sesame");

                StartCoroutine (safedoor.OpenDoor());
                safedoor.transform.Translate(-.4f, 0, 0); //-.4f);
                //door.OpenDoor();
            }

            //cur_input = "";
        }

        else //You've pressed a number
        {
            if (cur_input.Length < 4) //Don't want more than 4 characters entered for pwd
            {
                cur_input += input.ToString();
            }
        }
    }
}
