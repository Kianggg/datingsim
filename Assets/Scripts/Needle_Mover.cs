using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Needle_Mover : MonoBehaviour
{
    public Flowchart flowchart;

    // Update is called once per frame
    void Update()
    {
        float channel = flowchart.GetFloatVariable("Haunted_UI_Dial");
        float target = channel * 94.0f;
        target -= 47.0f;
        target *= -1;
        transform.rotation = Quaternion.Euler(0, 0, target);
    }
}
