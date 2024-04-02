using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Dial_Mover : MonoBehaviour
{
    public float rotationAmount = 2048.0f;

    public Flowchart flowchart;

    // Update is called once per frame
    void Update()
    {
        float channel = flowchart.GetFloatVariable("Haunted_UI_Dial");
        float target = channel * rotationAmount;
        target *= -1;
        transform.rotation = Quaternion.Euler(0, 0, target);
    }
}