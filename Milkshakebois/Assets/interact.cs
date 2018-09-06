using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class interact : MonoBehaviour {
    public bool touching = false;
    public string text = "";
    public bool active = false;
    public float heightFromPlayer = 2f;
    public float scale = 1f;
    public float textOffset = 0f;
    public Transform textBox;
    private Transform box;
    private Transform player;
    // Use this for initialization
    public void Start()
    {
        box = Instantiate(textBox, new Vector3(0f, 0f), Quaternion.identity);
        box.localScale = box.localScale * scale;
        box.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        touching = true;
        player = other.gameObject.transform;
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
            Vector3 screenPos = Camera.main.WorldToScreenPoint(new Vector3(box.position.x + (box.localScale.x)- textOffset , box.position.y +(box.localScale.y/2f)));
            GUIStyle style = GUI.skin.GetStyle("Label");
            style.alignment = TextAnchor.UpperLeft;
            GUI.Label(new Rect(Screen.width - screenPos.x , Screen.height - screenPos.y, 130 * scale, 70 * scale), text, style);
         
        }
        
    }
    // Update is called once per frame
    void Update ()
    {
		if(touching && Input.GetKeyDown(KeyCode.E))
        {
            box.transform.position = new Vector3(player.position.x, player.position.y + heightFromPlayer);
            box.GetComponent<MeshRenderer>().enabled = true;
            active = true;
            //Debug.Log(box.transform.position);
        }

	}
}
