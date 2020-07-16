using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.Text;

public class tracker_ids : MonoBehaviour
{
    public GameObject box_light;
    public GameObject box_medium;
    public GameObject box_heavy;
    public GameObject pipe;
    public Valve.VR.SteamVR_TrackedObject tracker_light;
    public Valve.VR.SteamVR_TrackedObject tracker_medium;
    public Valve.VR.SteamVR_TrackedObject tracker_heavy;
    public Valve.VR.SteamVR_TrackedObject tracker_pipe;


    // Start is called before the first frame update
    void Start()
    {
        // for changes:
        // E = LHR-C680B800 (also 00736)
        // F = LHR-5BA400D5 (also 03313)
        // G = LHR-771D2AE2 (also 00153)
        // L = LHR-3697AB8B (also 00329)
        // M = LHR-8BF7B612 (also 03437)
        // P = LHR-20C43916 (also 00024)
        // ? = LHR-403C8421 (also 00018)
        string light_id = ""; // tracker F or 03313
        string medium_id = "LHR-771D2AE2"; // tracker G or 00153
        string heavy_id = "LHR-403C8421"; //tracker 00018
        string pipe_id = "LHR-20C43916"; // tracker M or 03437
        tracker_light = box_light.GetComponent<Valve.VR.SteamVR_TrackedObject>();
        tracker_medium = box_medium.GetComponent<Valve.VR.SteamVR_TrackedObject>();
        tracker_heavy = box_heavy.GetComponent<Valve.VR.SteamVR_TrackedObject>();
        tracker_pipe = pipe.GetComponent<Valve.VR.SteamVR_TrackedObject>();

        ETrackedPropertyError error = new ETrackedPropertyError();
        StringBuilder sb = new StringBuilder();
        for (int i = 3; i < 15; i++)
        {
            OpenVR.System.GetStringTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_SerialNumber_String, sb, OpenVR.k_unMaxPropertyStringSize, ref error);
            var probablyUniqueDeviceSerial = sb.ToString();
            //Debug.Log(i + " : " + probablyUniqueDeviceSerial);

            if (string.Compare(probablyUniqueDeviceSerial, light_id) == 0)
            {
                tracker_light.SetDeviceIndex(i);
                //Debug.Log("without");
            }
            if (string.Compare(probablyUniqueDeviceSerial, medium_id) == 0)
            {
                tracker_medium.SetDeviceIndex(i);
                //Debug.Log("without");
            }
            if (string.Compare(probablyUniqueDeviceSerial, heavy_id) == 0)
            {
                tracker_heavy.SetDeviceIndex(i);
                //Debug.Log("without");
            }
            if (string.Compare(probablyUniqueDeviceSerial, pipe_id) == 0)
            {
                tracker_pipe.SetDeviceIndex(i);
                //Debug.Log("without");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
