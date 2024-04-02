using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using FMODUnity;
using FMOD.Studio;

public class Utility_Functions : MonoBehaviour
{
    public Flowchart flowchart;
    public GameObject Backgrounds;

    public EventInstance rainInst;
    public EventInstance carInst;
    public EventInstance dialInst;
    
    public EventReference rainEventRef;
    public EventReference carEventRef;
    public EventReference dialEventRef;

    private void Start()
    {

        rainInst = FMODUnity.RuntimeManager.CreateInstance(rainEventRef);
        carInst = FMODUnity.RuntimeManager.CreateInstance(carEventRef);
        dialInst = FMODUnity.RuntimeManager.CreateInstance(dialEventRef);

    }

    private void Update()
    {
        // Get parameters
        float rain = flowchart.GetFloatVariable("Rain_Intensity");
        float car = flowchart.GetFloatVariable("Car_Nearness");
        float dial = flowchart.GetFloatVariable("Haunted_UI_Dial");

        // Set parameters
        rainInst.setParameterByName("Rain Intensity", rain);
        carInst.setParameterByName("car nearness", car);
        dialInst.setParameterByName("Haunted_UI_Dial", dial);
    }

    public void StopAllAudio()
    {
        FMOD.Studio.Bus playerBus = FMODUnity.RuntimeManager.GetBus("bus:/player");
        playerBus.stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void SetBackground()
    {
        string target = flowchart.GetStringVariable("background");
        foreach (Transform child in Backgrounds.transform)
        {
            if (child.gameObject.name == target)
            {
                child.gameObject.SetActive(true);
            }
            else { child.gameObject.SetActive(false); }
        }
    }

    // Public functions to play the sounds
    // I use these in conjunction with the Fungus flowchart
    // to call FMOD-controlled audio from specific places in the narrative.

    public void playSound(string soundToPlay)
    {
        string eventFolder = "event:/";
        string result = eventFolder + soundToPlay;
        FMODUnity.RuntimeManager.PlayOneShot(result);
    }

    public void startAmb(string ambToPlay)
    {
        switch (ambToPlay)
        {
            case "rain":
                rainInst.start();
                break;
            case "car":
                carInst.start();
                break;
            case "dial":
                dialInst.start();
                break;
            default:
                Debug.Log("Ambience string " + ambToPlay + " not found.");
                break;
        }
    }

    public void stopAmb(string ambToStop)
    {
        switch (ambToStop)
        {
            case "rain":
                rainInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case "car":
                carInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case "dial":
                dialInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            default:
                Debug.Log("Ambience string " + ambToStop + " not found.");
                break;
        }
    }

}
