using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HandTrack : MonoBehaviour
{
    //float timer = 0.0f;
    public GameObject leftobj;
    public GameObject rightobj;

    public SteamVR_Action_Single squeezeAction;
    float triggerValue;
    public bool triggerOn = false;
    public bool handRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        leftobj = GameObject.Find("LeftHand");
        rightobj = GameObject.Find("RightHand");
    }

    // Update is called once per frame
    void Update()
    {
        triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);

        if (triggerValue > 0.0f)
        {
            print("Trigger is pressed.");
            triggerOn = true;
        }
        else
        {
            triggerOn = false;
        }

        if (handRotating)
        {
            leftobj.GetComponent<Hand>().Hide();
            rightobj.GetComponent<Hand>().Hide();
        }

        else
        {
            leftobj.GetComponent<Hand>().Show();
            rightobj.GetComponent<Hand>().Show();
        }

        /*if (timer >= 2.0f)
        {
            Debug.Log(rightobj.transform.position.x);
            Debug.Log(rightobj.transform.position.y);
            Debug.Log(rightobj.transform.position.z);
            timer = 0;
        }

        else
        {
            timer += Time.deltaTime;
        }*/
    }
}
