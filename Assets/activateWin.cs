using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateWin : MonoBehaviour {

    public GameObject youWin;
    private bool activated = false;

    // Use this for initialization
    private void Update()
    {
        if (!activated)
        {
            if (!youWin.GetComponent<youWin>().active)
            {
                youWin.GetComponent<youWin>().active = true;
                activated = true;
            }
            
        }
    }

}
