using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPressueValue : MonoBehaviour
{
    // Starting y-coordinate is -0.05 below Gauge parent object
	// Start current at maximum value of 15
	public int current = 0;
	public int difference = 0;
	
	int counter = 0;
	public int countMax = 10;

	float speed = 1.0f;
	float toMove = 0.0f;

    public AudioClip sfx;
    public AudioSource sfxSource;

	// Start is called before the first frame update
    void Start()
    {
        speed = speed / countMax;

        sfxSource.clip = sfx;
    }

    // Update is called once per frame
    void Update()
    {
        int total = GameObject.Find("AirRoomHandler").GetComponent<AirRoomHandler>().sumTotal;

		if(total != current)
		{

			difference = total - current;

			current = total;
			
			toMove = 2.0f * difference / 15.0f;

            sfxSource.Play();

		}

		if (counter < countMax && toMove != 0.0f)
		{
			counter++;
			transform.Translate(0.0f, toMove * speed, 0.0f);
		}

		if (counter >= countMax && toMove != 0.0f)
		{
			counter = 0;
			toMove = 0.0f;
		}
    }
}
