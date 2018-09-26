using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_controller : MonoBehaviour {

    public float jump_height = 10;
    public float speed = 1;
    public float bullet_speed = 3;
    public GameObject bullet;
    private int jump_switch = 0;
    private int shoot_switch = 0;
    private float shoot_timer = 0;
    private Rigidbody2D m_Rigidbody;

    // Use this for initialization
    void Start () {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if(m_Rigidbody.velocity.y == 0)
        {
            m_Rigidbody.velocity = transform.up * jump_height;
            jump_switch =  Random.Range(0, 2);
            if(jump_switch == 0)
            {
                m_Rigidbody.velocity = -transform.right * speed + new Vector3(0, m_Rigidbody.velocity.y, 0);
            }
            else
            {
                m_Rigidbody.velocity = transform.right * speed + new Vector3(0, m_Rigidbody.velocity.y, 0);
            }  
        }

        shoot_switch = Random.Range(0, 100);
        if(shoot_switch == 0 && shoot_timer <= 0)
        {
            GameObject bulletClone = Instantiate(bullet,transform.position + transform.forward * 4,Quaternion.identity,gameObject.transform);
            Rigidbody2D cloneBody = bulletClone.GetComponent<Rigidbody2D>();
            cloneBody.velocity = -transform.right * bullet_speed;
            shoot_timer += 3;
        }
        if(shoot_timer > 0)
        {
            shoot_timer -= Time.deltaTime;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" && collision.contacts[0].normal.x == 0.0)
        {
            m_Rigidbody.velocity = new Vector3(0, m_Rigidbody.velocity.y, 0);
        }
    }
}
