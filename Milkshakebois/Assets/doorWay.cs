using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorWay : MonoBehaviour {

    public GameObject otherDoorWay;
    public bool active = false;
    public GameObject fade;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        active = true;
        player = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        active = false;
        player = null;
    }

    public void Start()
    {
        fade.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 0f);
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
                player.transform.position = otherDoorWay.transform.position;
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
