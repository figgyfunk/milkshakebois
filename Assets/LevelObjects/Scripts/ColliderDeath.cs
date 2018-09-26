using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDeath : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            //insert death code here
            collision.gameObject.transform.position = collision.gameObject.GetComponent<SetSpawnPoint>().respawn_node.transform.position;
        }
    }
}
