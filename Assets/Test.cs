using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float timeCounter = 0;

    //float speed;
    float width;
    float height;

    public int rotations = 0;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 5;
        width = 2;
        height = 1.5f;
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
        Debug.Log(transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {


        timeCounter += Time.deltaTime;

        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }
}
