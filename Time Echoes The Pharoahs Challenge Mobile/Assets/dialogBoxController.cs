using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideUI()
    {
        this.gameObject.SetActive(false);
    }

    public bool showUI(string good, string neutral, string sarcastic)
    {
        
        gameObject.SetActive(true);
        return true;

    }
}
