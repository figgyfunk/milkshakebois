using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour {

    public Vector3 destOffset;
    public float speed;

    private Vector3 startLoc;
    private Vector3 endLoc;

    // Use this for initialization
    void Start () {
        startLoc = transform.position;
        endLoc = startLoc + destOffset;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(startLoc, endLoc, 
                                            (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
