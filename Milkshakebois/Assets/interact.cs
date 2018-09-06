using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class interact : MonoBehaviour {
    public bool touching = false;
    public string text = "";
    public bool active = false;
    public GameObject box;
    public float x;
    public float y;
    public float letterPause = .2f;
    private string printText = "";
    // Use this for initialization
    public void Start()
    {
        box.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        touching = true;
    }
    private void OnTriggerExit(Collider other)
    {
        touching = false;
        box.GetComponent<MeshRenderer>().enabled = false;
        GUI.enabled = false;
        active = false;
    }
    void OnGUI()
    {
        if(active)
        {
            GUI.enabled = true;
            GUI.Label(new Rect(160f, 2f, x, y), printText);
         
        }
        
    }
    // Update is called once per frame
    void Update ()
    {
		if(touching && Input.GetKeyDown(KeyCode.E))
        {
            box.GetComponent<MeshRenderer>().enabled = true;
            active = true;
            StartCoroutine(revealText());
        }

	}

    IEnumerator revealText()
    {
        foreach(char letter in text.ToCharArray())
        {
            printText += letter;
            yield return new WaitForSeconds(letterPause);
        }
        
    }
}
