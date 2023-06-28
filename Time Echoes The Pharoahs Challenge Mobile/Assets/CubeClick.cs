using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro library

public class CubeClick : MonoBehaviour
{
    // The TextMeshProUGUI element you want to change
    public TMP_Text textElement;

    // The next text you want to display
    public string nextText;

    // Check if the object has been clicked or touched
    private void Update()
    {
        Narrator narrator = FindObjectOfType<Narrator>();


        // Mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse click position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the raycast has hit this object
                if (hit.transform == this.transform)
                {
                    // Update the text
                    UpdateText();
                    narrator.OnTrigger("CubeTouch");
                    narrator.OnTrigger("Right");
                    narrator.OnTrigger("Left");



                }
            }
        }

        // Touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Create a ray from the touch position
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the raycast has hit this object
                if (hit.transform == this.transform)
                {
                    // Update the text
                    UpdateText();
                    narrator.OnTrigger("CubeTouch");
                    narrator.OnTrigger("Right");
                    narrator.OnTrigger("Left");
                }
            }
        }
    }

    private void UpdateText()
    {
        // Update the text element's text
        textElement.text = nextText;
    }
}
