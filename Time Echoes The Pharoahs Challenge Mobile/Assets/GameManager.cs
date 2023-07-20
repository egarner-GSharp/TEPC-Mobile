using Ai.Inworld.Studio.V1Alpha;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TriggerSender triggerSender;
    public GameObject PlayerDialogueUI;
    public AudioControl Chrono;
    public AudioControl pharaoh;
    public bool nearPharaoh;

    public bool playing = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Chrono line 0 - Intro to Scene w/Dialogue box "Alright. I can tell by your vital signs...."
        if (Chrono.voiceLines[0].playedAlready == false && !playing)
        {
            playing = true;
            StartCoroutine(sendCAT("0", true));
            //triggerSender.chronoAudioSender("0");
            //Chrono.OnTrigger("0");

        }
        //Chrono line 1 - "That’s great. Now look around....."
        else if (Chrono.voiceLines[1].playedAlready == false && Chrono.voiceLines[0].playedAlready && !playing)
        {
            playing = true;
            StartCoroutine(sendCAT("1", false));
        }

        //Ramses line 0 - "What are you doing here....."
        else if (nearPharaoh && !pharaoh.voiceLines[0].playedAlready && Chrono.voiceLines[1].playedAlready && !playing)
        {
            playing = true;
            StartCoroutine(sendPAT("0", false));
            //StartCoroutine(sendCAT("2", 0, false));
        }

        //Chrono - Uh-oh
        else if (Chrono.voiceLines[2].playedAlready == false && nearPharaoh && pharaoh.voiceLines[0].playedAlready && !playing)
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }

        //TimeMinions Animations flying into temple

        /* //Chrono - Quick Use your.....
        else if ()
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }
        */

        /* //Ramses - Who are you
        else if ()
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }
        */

        /* //Ramses - I knew it
        else if ()
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }
        */

        /* //Ramses - But Why
        else if ()
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }
        */

        /* //Ramses - So, you can't
        else if ()
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }
        */

        /* //Ramses - Well, you can start
        else if ()
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }
        */

        /* //Chrono - Nice save back there, kid.
        else if ()
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }
        */

        /* //Chrono - This is gonna take
        else if ()
        {
            playing = true;
            StartCoroutine(sendCAT("2", false));
        }
        */








        //testing/debuging old code
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            triggerSender.chronoAudioSender("0");

            for (int i = 0; i < Chrono.voiceLines.Length; i++)
            {
                Debug.Log(Chrono.voiceLines[i].playedAlready);

            }

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            triggerSender.pharaohAudioSender("0");
        }


        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            PlayerDialogueUI.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerDialogueUI.gameObject.SetActive(false);
        }
    }

    IEnumerator sendCAT(string trigger, bool displayUI)
    {
        Chrono.OnTrigger(trigger);
        yield return new WaitForSeconds(Chrono.voiceLines[int.Parse(trigger)].voiceLine.length);

        if (displayUI)
        {
            StartCoroutine(DisplayDialogue("Test", 10f));
            //PlayerDialogueUI.gameObject.SetActive(true);
        }
        else { playing = false; }
    }

    IEnumerator sendPAT(string trigger, bool displayUI)
    {
        pharaoh.OnTrigger(trigger);
        yield return new WaitForSeconds(pharaoh.voiceLines[int.Parse(trigger)].voiceLine.length);
     
        if (displayUI)
        {
            StartCoroutine(DisplayDialogue("Test", 10f));
        }
        else { playing = false; }


        //pharaoh.voiceLines[int.Parse(trigger)].playedAlready = true;

    }

    IEnumerator DisplayDialogue(string Message, float timeToWait)
    {
        PlayerDialogueUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeToWait);
        playing = false;

    }

}
