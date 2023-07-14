using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Started Up");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool isWalking = animator.GetBool("isWalking");

        bool swattingPressed =Input.GetKey("s");
        bool isSwatting = animator.GetBool("isSwatting");

        bool talkingPressed = Input.GetKey("t");
        bool isTalking = animator.GetBool("isTalking");

        //Walking
        if (!isWalking && forwardPressed)
        {
            Debug.Log("Pressed W");

            animator.SetBool("isWalking", true);
        }

        if (isWalking && !forwardPressed)
        {
            Debug.Log("Pressed W");

            animator.SetBool("isWalking", false);
        }

        //Swatting
        if (!isSwatting && swattingPressed)
        {
            Debug.Log("Pressed S");

            animator.SetBool("isSwatting", true);
        }

        if (isSwatting && !swattingPressed)
        {
            Debug.Log("Pressed S");

            animator.SetBool("isSwatting", false);
        }

        //Talking
        if (!isTalking && talkingPressed)
        {
            Debug.Log("Pressed T");

            animator.SetBool("isTalking", true);
        }

        if (isTalking && !talkingPressed)
        {
            Debug.Log("Pressed T");

            animator.SetBool("isTalking", false);
        }
    }
}
