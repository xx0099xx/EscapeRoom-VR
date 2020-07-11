using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from
//https://stackoverflow.com/questions/37443851/unity3d-check-microphone-input-volume
public class MicInput : MonoBehaviour
{
    #region SingleTon

    public MicInput Inctance { set; get; }

    #endregion

    public GameObject portal;
    public Teleport teleportation;
    public float MicLoudness;
    public float MicLoudnessinDecibels;
    public GameObject puzzle;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject fire5;
    public GameObject fire6;
    public GameObject fire7;
    public GameObject fire8;
    public GameObject fire9;
    public GameObject head;
    public int blow1 = 0;
    public int blow2 = 0;
    public int blow3 = 0;
    public int blow4 = 0;
    public int blow5 = 0;
    public int blow6 = 0;
    public int blow7 = 0;
    public int blow8 = 0;
    public int blow9 = 0;
    public GameObject aura1;
    public GameObject aura2;
    public GameObject aura3;
    public GameObject aura4;
    public GameObject aura5;
    public GameObject aura6;
    public GameObject aura7;
    public GameObject aura8;
    public GameObject aura9;
    public int blowcount = 0;
    public int recount = 0;
    public int runmic = 0;
    public static int repro = 0;
    private string _device;
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public int stageclear = 0;
    public GameObject clearsound;

   
   


    //mic initialization
    public void InitMic()
    {
        if (_device == null)
        {
            _device = Microphone.devices[0];
        }
        _clipRecord = Microphone.Start(_device, true, 999, 44100);
        _isInitialized = true;
    }

    public void StopMicrophone()
    {
        Microphone.End(_device);
        _isInitialized = false;
    }


    AudioClip _clipRecord;
    AudioClip _recordedClip;
    int _sampleWindow = 128;

    //get data from microphone into audioclip
    float MicrophoneLevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    //get data from microphone into audioclip
    float MicrophoneLevelMaxDecibels()
    {

        float db = 20 * Mathf.Log10(Mathf.Abs(MicLoudness));

        return db;
    }

    public float FloatLinearOfClip(AudioClip clip)
    {
        StopMicrophone();

        _recordedClip = clip;

        float levelMax = 0;
        float[] waveData = new float[_recordedClip.samples];

        _recordedClip.GetData(waveData, 0);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _recordedClip.samples; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    public float DecibelsOfClip(AudioClip clip)
    {
        StopMicrophone();

        _recordedClip = clip;

        float levelMax = 0;
        float[] waveData = new float[_recordedClip.samples];

        _recordedClip.GetData(waveData, 0);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _recordedClip.samples; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }

        float db = 20 * Mathf.Log10(Mathf.Abs(levelMax));

        return db;
    }
    void Start()
    {
        teleportation = portal.GetComponent<Teleport>();
        clearsound.SetActive(false);
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

    }
    void Update()
    {
        // levelMax equals to the highest normalized value power 2, a small number because < 1
        // pass the value to a static var so we can access it from anywhere
        MicLoudness = MicrophoneLevelMax();
        MicLoudnessinDecibels = MicrophoneLevelMaxDecibels();
        float db = MicLoudnessinDecibels;
    
        if (runmic == 0)
        {
            InitMic();
            runmic = 1;
        }
        
        //Debug.Log("Volume is " + MicLoudness.ToString("##.#####") + ", decibels is :" + MicLoudnessinDecibels.ToString("######"));
        float Distance1 = Vector3.Distance(fire1.transform.position, head.transform.position);
        float Distance2 = Vector3.Distance(fire2.transform.position, head.transform.position);
        float Distance3 = Vector3.Distance(fire3.transform.position, head.transform.position);
        float Distance4 = Vector3.Distance(fire4.transform.position, head.transform.position);
        float Distance5 = Vector3.Distance(fire5.transform.position, head.transform.position);
        float Distance6 = Vector3.Distance(fire6.transform.position, head.transform.position);
        float Distance7 = Vector3.Distance(fire7.transform.position, head.transform.position);
        float Distance8 = Vector3.Distance(fire8.transform.position, head.transform.position);
        float Distance9 = Vector3.Distance(fire9.transform.position, head.transform.position);
        if (db < 1 && db > -40f && fire1.activeSelf == true && Distance1 < 0.4)
        {
            fire1.SetActive(false);
            blow1 = 2;
            blowcount += 1;
        }
        if (db < 1 && db > -40f && fire2.activeSelf == true && Distance2 < 0.4)
        {
            fire2.SetActive(false);
            blow2 = 3;
            blowcount += 1;
        }
        if (db < 1 && db > -40f && fire3.activeSelf == true && Distance3 < 0.4)
        {
            fire3.SetActive(false);
            blow3 = 2;
            blowcount += 1;
        }
        if (db < 1 && db > -40f && fire4.activeSelf == true && Distance4 < 0.4)
        {
            fire4.SetActive(false);
            blow4 = 3;
            blowcount += 1;
        }
        if (db < 1 && db > -40f && fire5.activeSelf == true && Distance5 < 0.4)
        {
            fire5.SetActive(false);
            blow5 = 4;
            blowcount += 1;
        }
        if (db < 1 && db > -40f && fire6.activeSelf == true && Distance6 < 0.4)
        {
            fire6.SetActive(false);
            blow6 = 3;
            blowcount += 1;
        }
        if (db < 1 && db > -40f && fire7.activeSelf == true && Distance7 < 0.4)
        {
            fire7.SetActive(false);
            blow7 = 2;
            blowcount += 1;
        }
        if (db < 1 && db > -40f && fire8.activeSelf == true && Distance8 < 0.4)
        {
            fire8.SetActive(false);
            blow8 = 3;
            blowcount += 1;
        }
        if (db < 1 && db > -40f && fire9.activeSelf == true && Distance9 < 0.4)
        {
            fire9.SetActive(false);
            blow9 = 2;
            blowcount += 1;
        }
        //Cube1
        if(blow1==2&&fire2.activeSelf==true)
        {
            fire2.SetActive(false);
            blow1 = blow1 - 1;
        }
        if (blow1 == 2 && fire2.activeSelf == false)
        {
            fire2.SetActive(true);
            blow1 = blow1 - 1;
        }
        if(blow1==1&&fire4.activeSelf==true)
        {
            fire4.SetActive(false);
            blow1 = 0;
        }
        if (blow1 == 1 && fire4.activeSelf == false)
        {
            fire4.SetActive(true);
            blow1 = 0;
        }
        //Cube2
        if (blow2==3&&fire1.activeSelf == false)
        {
            fire1.SetActive(true);
            blow2 = blow2 - 1;
        }
        if (blow2==3&&fire1.activeSelf==true)
        {
            fire1.SetActive(false);
            blow2 = blow2 - 1;
        }
        if (blow2 == 2 && fire3.activeSelf == false)
        {
            fire3.SetActive(true);
            blow2 = blow2 - 1;
        }
        if (blow2 == 2 && fire3.activeSelf == true)
        {
            fire3.SetActive(false);
            blow2 = blow2 - 1;
        }
        if (blow2 == 1 && fire5.activeSelf == false)
        {
            fire5.SetActive(true);
            blow2 = 0;
        }
        if (blow2 == 1 && fire5.activeSelf == true)
        {
            fire5.SetActive(false);
            blow2 = 0;
        }
        //Cube3
        if (blow3 == 2 && fire2.activeSelf == true)
        {
            fire2.SetActive(false);
            blow3 = blow3 - 1;
        }
        if (blow3 == 2 && fire2.activeSelf == false)
        {
            fire2.SetActive(true);
            blow3 = blow3 - 1;
        }
        if (blow3 == 1 && fire6.activeSelf == true)
        {
            fire6.SetActive(false);
            blow3 = 0;
        }
        if (blow3 == 1 && fire6.activeSelf == false)
        {
            fire6.SetActive(true);
            blow3 = 0;
        }
        //Cube4
        if (blow4 == 3 && fire1.activeSelf == false)
        {
            fire1.SetActive(true);
            blow4 = blow4 - 1;
        }
        if (blow4 == 3 && fire1.activeSelf == true)
        {
            fire1.SetActive(false);
            blow4 = blow4 - 1;
        }
        if (blow4 == 2 && fire5.activeSelf == false)
        {
            fire5.SetActive(true);
            blow4 = blow4 - 1;
        }
        if (blow4 == 2 && fire5.activeSelf == true)
        {
            fire5.SetActive(false);
            blow4 = blow4 - 1;
        }
        if (blow4 == 1 && fire9.activeSelf == false)
        {
            fire9.SetActive(true);
            blow4 = 0;
        }
        if (blow4 == 1 && fire9.activeSelf == true)
        {
            fire9.SetActive(false);
            blow4 = 0;
        }
        //Cube5
        if(blow5==4&&fire2.activeSelf==false)
        {
            fire2.SetActive(true);
            blow5 = blow5 - 1;
        }
        if (blow5 == 4 && fire2.activeSelf == true)
        {
            fire2.SetActive(false);
            blow5 = blow5 - 1;
        }
        if (blow5 == 3 && fire4.activeSelf == false)
        {
            fire4.SetActive(true);
            blow5 = blow5 - 1;
        }
        if (blow5 == 3 && fire4.activeSelf == true)
        {
            fire4.SetActive(false);
            blow5 = blow5 - 1;
        }
        if (blow5 == 2 && fire6.activeSelf == false)
        {
            fire6.SetActive(true);
            blow5 = blow5 - 1;
        }
        if (blow5 == 2 && fire6.activeSelf == true)
        {
            fire6.SetActive(false);
            blow5 = blow5 - 1;
        }
        if (blow5 == 1 && fire8.activeSelf == false)
        {
            fire8.SetActive(true);
            blow5 = 0;
        }
        if (blow5 == 1 && fire8.activeSelf == true)
        {
            fire8.SetActive(false);
            blow5 = 0;
        }
        //Cube6
        if (blow6 == 3 && fire3.activeSelf == false)
        {
            fire3.SetActive(true);
            blow6 = blow6 - 1;
        }
        if (blow6 == 3 && fire3.activeSelf == true)
        {
            fire3.SetActive(false);
            blow6 = blow6 - 1;
        }
        if (blow6 == 2 && fire5.activeSelf == false)
        {
            fire5.SetActive(true);
            blow6 = blow6 - 1;
        }
        if (blow6 == 2 && fire5.activeSelf == true)
        {
            fire5.SetActive(false);
            blow6 = blow6 - 1;
        }
        if (blow6 == 1 && fire7.activeSelf == false)
        {
            fire7.SetActive(true);
            blow6 = 0;
        }
        if (blow6 == 1 && fire7.activeSelf == true)
        {
            fire7.SetActive(false);
            blow6 = 0;
        }
        //Cube7
        if (blow7 == 2 && fire6.activeSelf == true)
        {
            fire6.SetActive(false);
            blow7 = blow7 - 1;
        }
        if (blow7 == 2 && fire6.activeSelf == false)
        {
            fire6.SetActive(true);
            blow7 = blow7 - 1;
        }
        if (blow7 == 1 && fire8.activeSelf == true)
        {
            fire8.SetActive(false);
            blow7 = 0;
        }
        if (blow7 == 1 && fire8.activeSelf == false)
        {
            fire8.SetActive(true);
            blow7 = 0;
        }
        //Cube8
        if (blow8 == 3 && fire5.activeSelf == false)
        {
            fire5.SetActive(true);
            blow8 = blow8 - 1;
        }
        if (blow8 == 3 && fire5.activeSelf == true)
        {
            fire5.SetActive(false);
            blow8 = blow8 - 1;
        }
        if (blow8 == 2 && fire7.activeSelf == false)
        {
            fire7.SetActive(true);
            blow8 = blow8 - 1;
        }
        if (blow8 == 2 && fire7.activeSelf == true)
        {
            fire7.SetActive(false);
            blow8 = blow8 - 1;
        }
        if (blow8 == 1 && fire9.activeSelf == false)
        {
            fire9.SetActive(true);
            blow8 = 0;
        }
        if (blow8 == 1 && fire9.activeSelf == true)
        {
            fire9.SetActive(false);
            blow8 = 0;
        }
        //Cube9
        if (blow9 == 2 && fire4.activeSelf == true)
        {
            fire4.SetActive(false);
            blow9 = blow9 - 1;
        }
        if (blow9 == 2 && fire4.activeSelf == false)
        {
            fire4.SetActive(true);
            blow9 = blow9 - 1;
        }
        if (blow9 == 1 && fire8.activeSelf == true)
        {
            fire8.SetActive(false);
            blow9 = 0;
        }
        if (blow9 == 1 && fire8.activeSelf == false)
        {
            fire8.SetActive(true);
            blow9 = 0;
        }
        if(blowcount==1)
        {
            aura1.SetActive(true);
        }
        if (blowcount == 2)
        {
            aura2.SetActive(true);
        }
        if (blowcount == 3)
        {
            aura3.SetActive(true);
        }
        if (blowcount == 4)
        {
            aura4.SetActive(true);
        }
        if (blowcount == 5)
        {
            aura5.SetActive(true);
        }
        if (blowcount == 6)
        {
            aura6.SetActive(true);
        }
        if (blowcount == 7)
        {
            aura9.SetActive(true);
        }
        if (blowcount == 8)
        {
            aura8.SetActive(true);
        }
        if (blowcount == 9)
        {
            aura7.SetActive(true);
        }
        if(blowcount==10)
        {
            MicInput.repro = 1;
            blowcount = 0;
            puzzle.SetActive(false);
            
            
        }
        if(blowcount==1)
        {
            hint1.SetActive(true);
        }
        if(blowcount==2)
        {
            hint2.SetActive(true);
        }
        if(blowcount==3)
        {
            hint3.SetActive(true);
        }
        if(fire1.activeSelf==false&& fire2.activeSelf == false && fire3.activeSelf == false && fire4.activeSelf == false && fire5.activeSelf == false && fire6.activeSelf == false && fire7.activeSelf == false && fire8.activeSelf == false && fire9.activeSelf == false)
        {
            stageclear = 1;
            teleportation.solved = true;
            clearsound.SetActive(true);
        }
                //Debug.Log("Distance is" + Distance1+ " " + Distance2+" " + Distance3 +" "+ Distance4 + " "+ Distance5 +" "+ Distance6+" " + Distance7 +" "+ Distance8 +" "+ Distance9);
    }

    bool _isInitialized;
    // start mic when scene starts
    void OnEnable()
    {
        InitMic();
        _isInitialized = true;
        Inctance = this;
    }

    //stop mic when loading a new level or quit application


    // make sure the mic gets started & stopped when application gets focused
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Debug.Log("Focus");

            if (!_isInitialized)
            {
                //Debug.Log("Init Mic");
                InitMic();
            }
        }
    }
}
