using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTeleport : MonoBehaviour {

    public Vector3 destOffset;
    public float travelTime;
    public float start_percent;

    private Vector3 startLoc;
    private Vector3 endLoc;
    private float timer;

    // Use this for initialization
    void Start()
    {
        startLoc = transform.position;
        endLoc = startLoc + destOffset;
        timer = start_percent * travelTime;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float percent = timer / travelTime;

        if (percent > 1)
        {
            timer = 0;
            percent = 0;
        }

        transform.position = Vector3.Lerp(startLoc, endLoc, percent);
	}
}
