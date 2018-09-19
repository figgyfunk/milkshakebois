using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    public string nextScene;
    public void startGame()
    {
        SceneManager.LoadScene(nextScene);
    }
	
}
