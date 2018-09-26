using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_button : MonoBehaviour {

    public GameObject floor;
    private youWin wintext;

	// Use this for initialization
	void Start () {
        wintext = GetComponent<youWin>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(floor);
            wintext.active = true;
        }
    }
}
