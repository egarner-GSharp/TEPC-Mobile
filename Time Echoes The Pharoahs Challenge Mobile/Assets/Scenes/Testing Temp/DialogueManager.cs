using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) 
    { 
        Debug.Log("Starting Conversation with" +  dialogue.name);

        nameText.text = dialogue.name;
        sentences.Clear();


        foreach (string sentence in dialogue.sentences) 
        { 
            sentences.Enqueue(sentence); 
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;    
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);

        dialogueText.text = sentence;   
    }

    void EndDialogue()
    {
        Debug.Log("End Conversation");
    }

}
