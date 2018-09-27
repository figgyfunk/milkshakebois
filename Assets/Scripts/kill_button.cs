using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_button : MonoBehaviour {

    public GameObject floor;
    public AudioClip win_sound;
    private youWin wintext;
    private AudioSource musicplayer;
    private GameObject boss;

	// Use this for initialization
	void Start () {
        wintext = GetComponent<youWin>();
        musicplayer = GameObject.Find("Music Player").GetComponent<AudioSource>();
        boss = GameObject.Find("Boss");
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

            musicplayer.loop = false;
            musicplayer.Stop();
            musicplayer.PlayOneShot(win_sound);

            boss.GetComponent<Collider2D>().enabled = false;
        }
    }
}
