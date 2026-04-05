using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    //scene index => main menu 0, game 1, loose 2, win 3, credits 4...
    public void quitGame()
    {
        Application.Quit();
    }
    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void loadLooseScene()
    {
        SceneManager.LoadScene(2);
    }
    public void loadWinScene()
    {
        SceneManager.LoadScene(3);
    }
    public void loadCreditsScene()
    {
        SceneManager.LoadScene(4);
    }

}
