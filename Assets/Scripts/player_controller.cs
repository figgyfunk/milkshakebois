using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

    public float speed = 1f;
    public float jumpheight = 10f;
    public Sprite main_cube;
    public Sprite outline;
    public GameObject spriteObject;
    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer currImage;

    private bool incorporeal = false;

    // Use this for initialization
    void Start () {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        currImage = spriteObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("left")) {
            m_Rigidbody.velocity = -transform.right * speed + new Vector3(0,m_Rigidbody.velocity.y,0);
        }
        if(Input.GetKey("right")) {
            m_Rigidbody.velocity = transform.right * speed + new Vector3(0, m_Rigidbody.velocity.y, 0);
        }
        if(Input.GetKeyDown("up")){
            m_Rigidbody.velocity = transform.up * jumpheight;
        }
        if (Input.GetKey(KeyCode.X))
        {
            currImage.sprite = outline;
            incorporeal = true;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            currImage.sprite = main_cube;
            incorporeal = false;
        }
    }

    public bool Incorporeal
    {
        get
        {
            return incorporeal;
        }
        set
        {
            incorporeal = value;
        }
    }

}
