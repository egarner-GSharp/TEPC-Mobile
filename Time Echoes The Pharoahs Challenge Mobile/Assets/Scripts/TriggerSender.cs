using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSender : MonoBehaviour
{
    // Reference to the Narrator script
    public AudioControl chronoAudio;
    public AudioControl pharaohAudio;

    // Update is called once per frame
    void Update()
    {
 
    }

    public void chronoAudioSender(string trigger)
    {
        chronoAudio.OnTrigger(trigger);
    }

    public void pharaohAudioSender(string trigger)
    {
        pharaohAudio.OnTrigger(trigger);
    }
}
