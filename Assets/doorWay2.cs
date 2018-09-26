using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class doorWay2 : MonoBehaviour {

	public string nextLevel;
	public string doorText;
    public bool active = false;
    public GameObject fade;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private GameObject player;
    public GameObject box;


    private void OnTriggerEnter2D(Collider2D other)
    {
        active = true;
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player.gameObject.name);
        box.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        active = false;
        player = null;
        box.GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnGUI()
    {
        if (active)
        {
            GUI.Label(new Rect(400f, 100f, 150, 100), doorText);
        }
    }
    public void Start()
    {
        fade.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 0f);
        box.GetComponent<MeshRenderer>().enabled = false;

    }

   
    public void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) && active)
        {
            
            
            active = false;
            fadeIn = true;
        }

        if (fadeIn)
        {
            if(fade.GetComponent<MeshRenderer>().material.color.a < 1f)
            {
                float currentAlpha = fade.GetComponent<MeshRenderer>().material.color.a;
                currentAlpha += .0001f / Time.deltaTime;
                fade.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, currentAlpha);
            }

            else
            {
                SceneManager.LoadScene(nextLevel);
                fadeIn = false;
                fadeOut = true;
            }
        }

        if (fadeOut)
        {
            if(fade.GetComponent<MeshRenderer>().material.color.a > 0f)
            {
                float currentAlpha = fade.GetComponent<MeshRenderer>().material.color.a;
                currentAlpha -= .0001f / Time.deltaTime;
                fade.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, currentAlpha);
            }
            else
            {
                fadeOut = false;
            }
        }
        
    }


}
