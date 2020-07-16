using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class waterspeed : MonoBehaviour
{
    public GameObject scale_object;
    public scale scale_script;
    public GameObject fire;
    public GameObject myActor;
    public NVIDIA.Flex.FlexSourceActor actor_script;
    public NVIDIA.Flex.FlexContainer container;
    public GameObject exit_light;
    public int fire_count;
    public DigitalRuby.PyroParticles.FireConstantBaseScript fire_script;
    public UnityEngine.AudioSource watersound;
    public GameObject portal;
    public Teleport teleportation;

    //public FlexSourceActor myScript;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(myActor);
        //myScript = myActor.GetComponents(typeof(Component));
        //Component[] x = fire.GetComponents(typeof(Component));
        //foreach (Component c in x)
        //{
        //    Debug.Log(c);
        //}

        fire_count = 0;
        actor_script = base.GetComponent<NVIDIA.Flex.FlexSourceActor>();
        scale_script = scale_object.GetComponent<scale>();
        fire_script = fire.GetComponent<DigitalRuby.PyroParticles.FireConstantBaseScript>();
        watersound = base.GetComponent<UnityEngine.AudioSource>();
        teleportation = portal.GetComponent<Teleport>();

        //Debug.Log(s);

        //container = script.container;
        //Debug.Log(container);
        //Int32[] particles = container.AllocParticles(3);
        //Debug.Log(particles);
        //foreach (Int32 i in particles)
        //{
        //    Debug.Log(i);
        //}
        ////Debug.Log(container.AllocParticles(1));
        ///


    }

    // Update is called once per frame
    void Update()
    {

        if(actor_script.fireInteraction)
        {
            Debug.Log("YEHAH");
            fire_count++;
            Debug.Log("increased " + fire_count);
            if (fire_count > 100)
            {
                fire_script.Stop();
                //fire.SetActive(false);
                //exit_light.SetActive(true);
            }
        }
        else
        {
            fire_count = Math.Max (fire_count - 1, 0);
            //Debug.Log("decreased " + fire_count);
        }


        if(fire == null)
        {
            exit_light.SetActive(true);
            teleportation.solved = true;
        }
        //else
        //{
        //    Debug.Log("NOOOO");
        //    fire.SetActiveRecursively(true);
        //}

        actor_script.startSpeed = scale_script.weight + 0.5f;
        watersound.pitch = Math.Min(scale_script.weight / 5f * 2f + 0.8f, 2.8f);

        //if(Input.GetKey(KeyCode.UpArrow))
        //{
        //    //myActor.startSpeed = 20;
        //    //Debug.Log("UP");
        //    script.startSpeed = Math.Min(script.startSpeed + 0.05f, 6);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    //myActor.startSpeed = 20;
        //    //Debug.Log("Down");
        //    script.startSpeed = Math.Max(script.startSpeed - 0.05f, 0.5f);
        //}
    }
}
