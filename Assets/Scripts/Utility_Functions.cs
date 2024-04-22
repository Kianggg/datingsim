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

    public EventInstance broadcastAdInst;
    public EventInstance broadcastEvacInst;
    public EventInstance broadcastIntroInst;
    public EventInstance broadcastDanceInst;
    public EventInstance masterDialInst;

    public EventReference broadcastAdRef;
    public EventReference broadcastEvacRef;
    public EventReference broadcastIntroRef;
    public EventReference broadcastDanceRef;
    public EventReference masterDialRef;

    private void Start()
    {

        broadcastAdInst = FMODUnity.RuntimeManager.CreateInstance(broadcastAdRef);
        broadcastEvacInst = FMODUnity.RuntimeManager.CreateInstance(broadcastEvacRef);
        broadcastIntroInst = FMODUnity.RuntimeManager.CreateInstance(broadcastIntroRef);
        broadcastDanceInst = FMODUnity.RuntimeManager.CreateInstance(broadcastDanceRef);
        masterDialInst = FMODUnity.RuntimeManager.CreateInstance(masterDialRef);

    }

    private void Update()
    {
        // Get parameters
        float dial = flowchart.GetFloatVariable("Haunted_UI_Dial");

        // Set parameters
        broadcastAdInst.setParameterByName("Haunted_UI_Dial", dial);
        broadcastEvacInst.setParameterByName("Haunted_UI_Dial", dial);
        broadcastIntroInst.setParameterByName("Haunted_UI_Dial", dial);
        broadcastDanceInst.setParameterByName("Haunted_UI_Dial", dial);
        masterDialInst.setParameterByName("Haunted_UI_Dial", dial);
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
            case "ad":
                broadcastAdInst.start();
                break;
            case "evac":
                broadcastEvacInst.start();
                break;
            case "intro":
                broadcastIntroInst.start();
                break;
            case "dance":
                broadcastDanceInst.start();
                break;
            case "dial":
                masterDialInst.start();
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
            case "ad":
                broadcastAdInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case "evac":
                broadcastEvacInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case "intro":
                broadcastIntroInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case "dance":
                broadcastDanceInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            case "dial":
                masterDialInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                break;
            default:
                Debug.Log("Ambience string " + ambToStop + " not found.");
                break;
        }
    }

}
