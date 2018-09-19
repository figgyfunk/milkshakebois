using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour {

    public GameObject respawn_node;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Respawn Node"))
        {
            respawn_node = collision.gameObject;
        }
    }
}
