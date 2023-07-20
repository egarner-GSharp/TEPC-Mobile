using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public string playerTag = "Player";
    private GameManager gameManagerScript;

    private void Start()
    {
        // Find the GameManager and get the script attached to it
        GameObject gameManager = GameObject.FindWithTag("GameManager");
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            gameManagerScript.nearPharaoh = true;
            Debug.Log("entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            gameManagerScript.nearPharaoh = false;
            Debug.Log("exited");

        }
    }
}
