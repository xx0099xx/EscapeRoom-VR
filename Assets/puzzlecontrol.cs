using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class puzzlecontrol : MonoBehaviour
{
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;
    public GameObject puzzle4;
    public GameObject puzzle5;
    public GameObject puzzle6;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject fire5;
    public GameObject fire6;
    public GameObject fire7;
    public GameObject fire8;
    public GameObject fire9;
    public GameObject aura1;
    public GameObject aura2;
    public GameObject aura3;
    public GameObject aura4;
    public GameObject aura5;
    public GameObject aura6;
    public GameObject aura7;
    public GameObject aura8;
    public GameObject aura9;
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public int resetcounter=0;
    // Start is called before the first frame update
    void Start()
    {

        puzzle1.SetActive(true);

        puzzle2.SetActive(false);

        puzzle3.SetActive(false);
        puzzle4.SetActive(false);
        puzzle5.SetActive(false);
        puzzle6.SetActive(false);

    }
    void Update()
    { 
        if(resetcounter==0&&MicInput.repro==1)
        {
            puzzle2.SetActive(true);
            MicInput.repro = 0;
            resetcounter = resetcounter + 1;
        }
        if (resetcounter==1 && MicInput.repro == 1)
        {
            puzzle3.SetActive(true);
            MicInput.repro = 0;
            resetcounter = resetcounter + 1;
        }
        if (resetcounter == 2 && MicInput.repro == 1)
        {
            puzzle4.SetActive(true);
            MicInput.repro = 0;
            resetcounter = resetcounter + 1;
        }
        if (resetcounter == 3 && MicInput.repro == 1)
        {
            puzzle5.SetActive(true);
            MicInput.repro = 0;
            resetcounter = resetcounter + 1;
        }
        if (resetcounter == 4 && MicInput.repro == 1)
        {
            puzzle6.SetActive(true);
            MicInput.repro = 0;
            resetcounter = resetcounter + 1;
        }
        if (resetcounter >= 5&&MicInput.repro==1)
        {
            puzzle6.SetActive(true);
            fire1.SetActive(false);
            fire2.SetActive(false);
            fire3.SetActive(false);
            fire4.SetActive(false);
            fire5.SetActive(true);
            fire6.SetActive(false);
            fire7.SetActive(false);
            fire8.SetActive(false);
            fire9.SetActive(false);
            aura1.SetActive(false);
            aura2.SetActive(false);
            aura3.SetActive(false);
            aura4.SetActive(false);
            aura5.SetActive(false);
            aura6.SetActive(false);
            aura7.SetActive(false);
            aura8.SetActive(false);
            aura9.SetActive(false);
            hint1.SetActive(false);
            hint2.SetActive(false);
            hint3.SetActive(false);
            MicInput.repro = 0;

        }
    }
}
