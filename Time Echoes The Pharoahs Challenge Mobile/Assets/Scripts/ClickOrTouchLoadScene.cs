using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ClickOrTouchLoadScene : MonoBehaviour
{
    public int sceneIndex;

    private void Update()
    {
        // Mouse click
        if (Input.GetMouseButtonDown(0))
        {
            CheckHit(Input.mousePosition);
        }

        // Touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CheckHit(Input.GetTouch(0).position);
        }
    }

    private void CheckHit(Vector3 position)
    {
        // Create a ray from the click/touch position
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the raycast has hit this object
            if (hit.transform == this.transform)
            {
                // Log to console
                Debug.Log("The cube has been clicked/touched.");

                // Load the scene
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
