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
        // Check if the trigger matches the current voice line's trigger
        if (currentLine < voiceLines.Length && voiceLines[currentLine].trigger == trigger)
        {
            // Play the voice line
            StartCoroutine(PlayVoiceLine());
        }
    }

    private IEnumerator PlayVoiceLine()
    {
        // Play the current voice line
        audioSource.clip = voiceLines[currentLine].voiceLine;
        audioSource.Play();

        // Wait for the voice line to finish playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Move to the next voice line
        currentLine++;

        // If the next line's trigger is empty, play it immediately
        if (currentLine < voiceLines.Length && string.IsNullOrEmpty(voiceLines[currentLine].trigger))
        {
            StartCoroutine(PlayVoiceLine());
        }
    }
}
