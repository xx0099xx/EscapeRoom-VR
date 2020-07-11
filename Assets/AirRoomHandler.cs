using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirRoomHandler : MonoBehaviour
{
    int[] binaryArray = {1, 2, 4, 8};
	int[] lockArray = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
	
	public int sumTotal = 0;

    public Material NewMaterial;    // Hint for correct value needed / if valve is on
    public Material NewMaterial2;   // If valve is off

	// Using the Fisher-Yates Shuffle to randomise the ordering of the valve values
	private static void ShuffleArray<T>(T[] array)
	{
		int n = array.Length;
		for (int i = 0; i < n-1; i++)
		{
			int r = i + Random.Range(0, n-i);
			T t = array[r];
			array[r] = array[i];
			array[i] = t;
		}
	}

    private void colourHints(int[] array)
    {
        for (int i = 0; i < 6; i++)
        {
            switch (array[i])
            {
                case 0:
                    GameObject.Find("Checker0").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 1:
                    GameObject.Find("Checker1").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 2:
                    GameObject.Find("Checker2").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 3:
                    GameObject.Find("Checker3").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 4:
                    GameObject.Find("Checker4").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 5:
                    GameObject.Find("Checker5").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 6:
                    GameObject.Find("Checker6").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 7:
                    GameObject.Find("Checker7").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 8:
                    GameObject.Find("Checker8").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 9:
                    GameObject.Find("Checker9").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 10:
                    GameObject.Find("Checker10").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 11:
                    GameObject.Find("Checker11").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 12:
                    GameObject.Find("Checker12").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 13:
                    GameObject.Find("Checker13").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                case 14:
                    GameObject.Find("Checker14").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

                default:
                    GameObject.Find("Checker15").GetComponent<MeshRenderer>().material = NewMaterial;
                    break;

            }
            //Debug.Log(array[i]);
        }
    }


	// Start is called before the first frame update
    void Start()
    {
		// Randomises the values assigned to each valve and lock
		ShuffleArray(binaryArray);
		ShuffleArray(lockArray);
        colourHints(lockArray);

		/*
		/Debug.Log(binaryArray[0]);
		/Debug.Log(binaryArray[1]);
		/Debug.Log(binaryArray[2]);
		Debug.Log(binaryArray[3]);

		Debug.Log(lockArray[0]);
		Debug.Log(lockArray[1]);
		Debug.Log(lockArray[2]);
		Debug.Log(lockArray[3]);
		Debug.Log(lockArray[4]);
		Debug.Log(lockArray[5]);
		*/

		GameObject valve1 = GameObject.Find("RedValve");
		valve1.GetComponent<Rotate>().valveValue = binaryArray[0];

		GameObject valve2 = GameObject.Find("YellowValve");
		valve2.GetComponent<Rotate>().valveValue = binaryArray[1];

		GameObject valve3 = GameObject.Find("GreenValve");		// Valve can finally count to 3
		valve3.GetComponent<Rotate>().valveValue = binaryArray[2];

		GameObject valve4 = GameObject.Find("BlueValve");
		valve4.GetComponent<Rotate>().valveValue = binaryArray[3];

		GameObject lock0 = GameObject.Find("Lock0");
		lock0.GetComponent<MoveLock>().lockvalue = lockArray[0];

		GameObject lock1 = GameObject.Find("Lock1");
		lock1.GetComponent<MoveLock>().lockvalue = lockArray[1];

		GameObject lock2 = GameObject.Find("Lock2");
		lock2.GetComponent<MoveLock>().lockvalue = lockArray[2];

		GameObject lock3 = GameObject.Find("Lock3");
		lock3.GetComponent<MoveLock>().lockvalue = lockArray[3];

		GameObject lock4 = GameObject.Find("Lock4");
		lock4.GetComponent<MoveLock>().lockvalue = lockArray[4];

		GameObject lock5 = GameObject.Find("Lock5");
		lock5.GetComponent<MoveLock>().lockvalue = lockArray[5];
    }

    // Update is called once per frame
    void Update()
    {
        GameObject valve1 = GameObject.Find("RedValve");
		GameObject valve2 = GameObject.Find("YellowValve");
		GameObject valve3 = GameObject.Find("GreenValve");
		GameObject valve4 = GameObject.Find("BlueValve");

		// Simple bool-to-int converter
		int redOn = valve1.GetComponent<Rotate>().isOn ? 1 : 0;
		int yellowOn = valve2.GetComponent<Rotate>().isOn ? 1 : 0;
		int greenOn = valve3.GetComponent<Rotate>().isOn ? 1 : 0;
		int blueOn = valve4.GetComponent<Rotate>().isOn ? 1 : 0;

		sumTotal = redOn * binaryArray[0] + yellowOn * binaryArray[1] + greenOn * binaryArray[2] + blueOn * binaryArray[3];

        // Change the colours of the lighths to signal if the valves are on or not
        if (redOn == 1)
        {
            GameObject.Find("Light1").GetComponent<MeshRenderer>().material = NewMaterial;
        }
        else
        {
            GameObject.Find("Light1").GetComponent<MeshRenderer>().material = NewMaterial2;
        }

        if (yellowOn == 1)
        {
            GameObject.Find("Light2").GetComponent<MeshRenderer>().material = NewMaterial;
        }
        else
        {
            GameObject.Find("Light2").GetComponent<MeshRenderer>().material = NewMaterial2;
        }

        if (greenOn == 1)
        {
            GameObject.Find("Light3").GetComponent<MeshRenderer>().material = NewMaterial;
        }
        else
        {
            GameObject.Find("Light3").GetComponent<MeshRenderer>().material = NewMaterial2;
        }

        if (blueOn == 1)
        {
            GameObject.Find("Light4").GetComponent<MeshRenderer>().material = NewMaterial;
        }
        else
        {
            GameObject.Find("Light4").GetComponent<MeshRenderer>().material = NewMaterial2;
        }

        // Ensures no out-of-bounds errors by clamping it to the minimum/maximum values
        if (sumTotal < 0)
		{
			sumTotal = 0;
		}

		if (sumTotal > 15)
		{
			sumTotal = 15;
		}
    }
}
