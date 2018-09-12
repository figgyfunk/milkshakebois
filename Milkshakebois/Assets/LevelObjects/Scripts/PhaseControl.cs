using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseControl : MonoBehaviour {

    private player_controller player_controller;
    private Collider2D collider;

	// Use this for initialization
	void Start () {
        player_controller = GameObject.Find("Player").GetComponent<player_controller>();
        collider = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        collider.enabled = !player_controller.Incorporeal;
    }
}
