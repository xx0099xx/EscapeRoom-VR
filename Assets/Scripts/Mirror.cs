using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All ideas taken from: https://www.youtube.com/watch?v=Ey8MHswqzko
public class Mirror : MonoBehaviour
{

    public Transform MirrorCam;
    public Transform PlayerCam;

    // Update is called once per frame
    void Update()
    {
        CalculateRotation();
    }

    public void CalculateRotation()
    {
        Vector3 dir = -(PlayerCam.position).normalized;// - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);

        rot.eulerAngles = transform.eulerAngles - rot.eulerAngles;

        MirrorCam.localRotation = rot;
    }

}
