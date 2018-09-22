using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseControl : MonoBehaviour {

    private player_controller player_controller;
    private Collider2D col;

	// Use this for initialization
	void Start () {
        player_controller = GameObject.Find("Player").GetComponent<player_controller>();
        col = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        col.enabled = !player_controller.Incorporeal;
    }
}
