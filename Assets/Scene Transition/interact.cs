using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class interact : MonoBehaviour {
    public bool touching = false;
    public string first = "";
    public string response = "";
    private string text;
    public bool active = false;
    public GameObject box;
    public float x;
    public float y;
    private float letterPause = .1f;
    private string printText = "";
    private bool typingDone = false;
    // Use this for initialization
    public void Start()
    {
        box.GetComponent<MeshRenderer>().enabled = false;
        text = first;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        touching = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        touching = false;
        box.GetComponent<MeshRenderer>().enabled = false;
        GUI.enabled = false;
        active = false;
        printText = "";
        typingDone = false;
        text = first;
    }
    void OnGUI()
    {
        if(active)
        {
            GUI.enabled = true;
            GUI.Label(new Rect(300f, 2f, 300, 100), printText);
         
        }
        
    }
    // Update is called once per frame
    void Update ()
    {
		if(touching)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (typingDone == false)
                {
                    box.GetComponent<MeshRenderer>().enabled = true;
                    active = true;
                    StartCoroutine(revealText());
                }
                else
                {
                    printText = "";
                    text = response;
                    StartCoroutine(revealText());
                }
                
            }
            
        }

	}

    IEnumerator revealText()
    {
        foreach(char letter in text.ToCharArray())
        {
            printText += letter;
            if(printText.Length == text.Length)
            {
                typingDone = true;
            }
            yield return new WaitForSeconds(letterPause);
        }
        
    }
}
