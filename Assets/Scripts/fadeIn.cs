using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<MeshRenderer>().material.color.a > 0f)
            {
                float currentAlpha = gameObject.GetComponent<MeshRenderer>().material.color.a;
                currentAlpha -= .0001f / Time.deltaTime;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, currentAlpha);
            }
	}
}
