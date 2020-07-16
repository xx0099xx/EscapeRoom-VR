using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeTextUpdate : MonoBehaviour
{
    TextMesh txt;
    public Safe safe;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = safe.cur_input;
    }
}
