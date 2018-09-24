﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class youWin : MonoBehaviour {

    public bool active;
    private GUIStyle style;
    public int fontSize = 100;
	// Use this for initialization
	void Start () {
        active = false;
        style = new GUIStyle();
        style.fontSize = fontSize;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        active = true;
    }

    private void OnGUI()
    {
        if (active)
        {
            GUI.Label(new Rect(Screen.width/2f - 50f, 150f, 100f, 100f), "You Win!", style);
        }
    }
}
