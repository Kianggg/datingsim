using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;

public class Station_UI : MonoBehaviour
{
    public Flowchart flowchart;
    public TextMeshProUGUI myNumber;

    // Update is called once per frame
    void Update()
    {
        float target = flowchart.GetFloatVariable("Haunted_UI_Dial");
        target = target * 100;
        int noDecimal = (int)target;
        myNumber.text = noDecimal.ToString();
    }
}
