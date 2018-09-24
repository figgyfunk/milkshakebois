using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuStart(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(SceneManager.GetActiveScene().name);
        if(collision.gameObject.tag == "Player" && SceneManager.GetActiveScene().name == "ChallengeTest")
        {
            SceneManager.LoadScene("Boss_Scene");
        }
        else if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(GoToLoop());
        }
    }

    IEnumerator GoToLoop()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("loopingPart");
    }
}
