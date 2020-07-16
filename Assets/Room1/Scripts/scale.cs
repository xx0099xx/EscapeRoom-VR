using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour
{
    public GameObject self;
    public GameObject fire;
    public GameObject cube1;
    public GameObject myActor;
    public NVIDIA.Flex.FlexSourceActor script;
    public NVIDIA.Flex.FlexContainer container;
    public int weight;

    // Start is called before the first frame update
    void Start()
    {
        Component[] x = myActor.GetComponents(typeof(Component));
        script = myActor.GetComponent<NVIDIA.Flex.FlexSourceActor>();
        weight = 0;
        //BoxCollider collider = self.GetComponent<BoxCollider>();
        //collider.size = new Vector3(collider.size.x, collider.size.y + 10f, collider.size.z);
    }

    // Update is called once per frame
    void Update()
    {
        ////Debug.Log(cube1.transform.position);
        //if (cube1.transform.position[0] > self.transform.position[0] - self.transform.scale[0] / 2 && cube1.transform.position[0] < self.transform.position[0] + self.transform.scale[0] / 2)
        //{
        //    if (cube1.transform.position[2] > self.transform.position[2] - self.transform.scale[2] / 2 && cube1.transform.position[2] < self.transform.position[2] + self.transform.scale[2] / 2)
        //    {
        //        //
        //    }
        //}
        //Debug.Log(weight);

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Box-light")
        {
            Debug.Log("Box-light");
            weight += 1;
        }
        if (col.gameObject.name == "Box-medium")
        {
            Debug.Log("Box-medium");
            weight += 2;
        }
        if (col.gameObject.name == "Box-heavy")
        {
            Debug.Log("Box-heavy");
            weight += 5;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Box-light")
        {
            Debug.Log("Box-light");
            weight -= 1;
        }
        if (col.gameObject.name == "Box-medium")
        {
            Debug.Log("Box-medium");
            weight -= 2;
        }
        if (col.gameObject.name == "Box-heavy")
        {
            Debug.Log("Box-heavy");
            weight -= 5;
        }
    }
}
