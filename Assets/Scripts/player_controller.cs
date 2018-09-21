using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class player_controller : MonoBehaviour {

    public float speed = 1f;
    public float jumpheight = 10f;
    public Sprite main_cube;
    public Sprite outline;
    public GameObject spriteObject;
    public Text scoreText;
    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer currImage;
    private int score = 0;

    private bool incorporeal = false;

    // Use this for initialization
    void Start () {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        currImage = spriteObject.GetComponent<SpriteRenderer>();
        GameObject tempObject = GameObject.Find("Score");
        if(tempObject != null)
        {
            scoreText = tempObject.GetComponent<Text>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("left")) {
            m_Rigidbody.velocity = -transform.right * speed + new Vector3(0,m_Rigidbody.velocity.y,0);
        }
        if(Input.GetKey("right")) {
            m_Rigidbody.velocity = transform.right * speed + new Vector3(0, m_Rigidbody.velocity.y, 0);
        }
        if(Input.GetKeyDown("up") && m_Rigidbody.velocity.y == 0){
            m_Rigidbody.velocity = transform.up * jumpheight;
        }
        if(!Input.GetKey("left") && !Input.GetKey("right") && !Input.GetKey("up"))
        {
            m_Rigidbody.velocity = new Vector3(0, m_Rigidbody.velocity.y, 0);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor" && collision.contacts[0].normal.x == 0.0)
        {
            transform.parent = collision.transform;
        }
        if(collision.gameObject.tag == "Bullet")
        {
            gameover();
        }
        if(collision.gameObject.tag == "Boss")
        {
            gameover();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
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

    public void gameover()
    {
        Camera.main.transform.parent = null;
        Destroy(gameObject);
    }

}
