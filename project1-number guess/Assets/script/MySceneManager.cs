using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void loadNext()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
    public void loadStart()
    {
        SceneManager.LoadScene(0);  
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
