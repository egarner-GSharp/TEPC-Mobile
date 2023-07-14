using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Narrator : MonoBehaviour
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
    private int currentLine = 0; // The current voice line index
    private bool isPlaying = false; // Whether a voice line is currently playing

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // If the first voice line's trigger is empty, start playing
        if (voiceLines.Length > 0 && string.IsNullOrEmpty(voiceLines[0].trigger))
        {
            StartCoroutine(PlayVoiceLine());
        }
    }

    public void OnTrigger(string trigger)
    {
        // Check if a voice line is currently playing
        if (isPlaying)
        {
            return; // If a voice line is playing, ignore new triggers
        }

        // Check if the trigger matches the current voice line's trigger
        if (currentLine < voiceLines.Length && voiceLines[currentLine].trigger == trigger)
        {
            // Play the current voice line
            StartCoroutine(PlayVoiceLine());
        }
    }

    private IEnumerator PlayVoiceLine()
    {
        // Set the playing flag to true
        isPlaying = true;

        // Play the current voice line
        audioSource.clip = voiceLines[currentLine].voiceLine;
        audioSource.Play();

        // Wait for the voice line to finish playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Move to the next voice line
        currentLine++;

        // Set the playing flag to false
        isPlaying = false;

        // If the next line's trigger is empty, play it immediately
        if (currentLine < voiceLines.Length && string.IsNullOrEmpty(voiceLines[currentLine].trigger))
        {
            StartCoroutine(PlayVoiceLine());
        }
    }
}
