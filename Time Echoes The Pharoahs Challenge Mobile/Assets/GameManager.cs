using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TriggerSender triggerSender;
    public GameObject PlayerDialogueUI;
    public AudioControl Chrono;
    public AudioControl pharaoh;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Chrono.voiceLines[0].playedAlready == false)
        {
            //triggerSender.chronoAudioSender("0");
            //PlayerDialogueUI.gameObject.SetActive(true);
            StartCoroutine(sendCAT("0", 16.5f, true));

        }

        else if (Chrono.voiceLines[1].playedAlready == false && Chrono.voiceLines[0].playedAlready)
        {
            StartCoroutine(sendCAT("1", 0, false));

        }



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

    IEnumerator sendCAT(string trigger, float timeToWait, bool displayUI)
    {
        triggerSender.chronoAudioSender(trigger);
        
        if (displayUI)
        {
            yield return new WaitForSeconds(timeToWait);
            PlayerDialogueUI.gameObject.SetActive(true);

        }


    }
}
