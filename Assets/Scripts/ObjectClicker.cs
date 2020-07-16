using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    
	public float force = 20;

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 100.0f))
			{
				if (hit.transform != null)
				{
					Rigidbody rb;

					if (rb = hit.transform.GetComponent<Rigidbody>())
					{
						PrintName(hit.transform.gameObject);
						LaunchIntoAir(rb);
					}
				}
			}
		}
    }

	private void PrintName(GameObject go)
	{
		print(go.name);
	}

	private void LaunchIntoAir (Rigidbody rig)
	{
		rig.AddForce(rig.transform.up * force, ForceMode.Impulse);
	}
}
