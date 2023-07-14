using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoAudioControl : MonoBehaviour
{

    // This struct will hold a voice line and the trigger required to play it
    [System.Serializable]
    public struct VoiceLineTriggerPair
    {
        public AudioClip voiceLine; // The voice line to play
        public string trigger; // The trigger needed to play the voice line
    }

    public VoiceLineTriggerPair[] voiceLines; // The array of voice lines and triggers

    private AudioSource audioSource; // The AudioSource to play the voice lines on
    private Dictionary<string, AudioClip> voiceDictionary; // To hold the mapping of triggers and voice lines

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Initialize the voiceDictionary
        voiceDictionary = new Dictionary<string, AudioClip>();

        // Populate the voiceDictionary
        foreach (var voiceLine in voiceLines)
        {
            voiceDictionary.Add(voiceLine.trigger, voiceLine.voiceLine);
        }
    }

    public void OnTrigger(string trigger)
    {
        // Check if the trigger exists in the dictionary and audioSource is not playing
        if (voiceDictionary.ContainsKey(trigger) && !audioSource.isPlaying)
        {
            // If yes, play the corresponding voice line
            PlayVoiceLine(voiceDictionary[trigger]);
        }
    }

    private void PlayVoiceLine(AudioClip voiceLine)
    {
        // Play the voice line
        audioSource.PlayOneShot(voiceLine);
    }
}
