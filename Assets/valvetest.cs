using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valvetest : MonoBehaviour
{
    public GameObject myParent;
    public GameObject thisRoom;
    public bool myTrigger = false;
    public bool isHand = false;
    // Start is called before the first frame update
    void Start()
    {
        thisRoom = GameObject.Find("AirRoomHandler");

        // Finds the name of the valve handler, so I can reuse the same script for all four
        string myName = this.gameObject.name;

        switch (myName)
        {
            case "RedHandTracker":
                //print("I am Red");
                myParent = GameObject.Find("RedValve");
                break;

            case "YellowHandTracker":
                //print("I am Yellow");
                myParent = GameObject.Find("YellowValve");
                break;

            case "GreenHandTracker":
                //print("I am Green");
                myParent = GameObject.Find("GreenValve");
                break;

            case "BlueHandTracker":
                //print("I am Blue");
                myParent = GameObject.Find("BlueValve");
                break;

            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        myTrigger = thisRoom.GetComponent<HandTrack>().triggerOn;

        if (myTrigger && isHand)
        {
            myParent.GetComponent<Rotate>().canRotate = true;
            SteamVR_Utils.Event.Send("hide_render_models", false);
            thisRoom.GetComponent<HandTrack>().handRotating = true;
        }

        else
        {
            myParent.GetComponent<Rotate>().canRotate = false;
            SteamVR_Utils.Event.Send("hide_render_models", true);
        }

        if(!myTrigger)
        {
            thisRoom.GetComponent<HandTrack>().handRotating = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        print("Found something...");
        print(other.gameObject.name);

        // Checks if at least one part of the hand is in the trigger
        // Thumb was chosen as the same part is used for both hand models
        if (other.gameObject.name == "thumb_distal")
        {
            isHand = true;
            print("Hand has entered.");
        }

        // Checks which hand we should be tracking
        if (other.gameObject.name == "finger_index_2_r")
        {
            myParent.GetComponent<Rotate>().handobj = GameObject.Find("RightHand");
        }

        if (other.gameObject.name == "finger_index_2_l")
        {
            myParent.GetComponent<Rotate>().handobj = GameObject.Find("LeftHand");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("Lost it...");
        print(other.gameObject.name);

        if (other.gameObject.name == "thumb_distal")
        {
            isHand = false;
            print("Hand has exited");
        }

    }
}
