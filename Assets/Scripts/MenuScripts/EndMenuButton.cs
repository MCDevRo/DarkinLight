using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuButton : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGane()
    {
        SceneManager.LoadScene(5);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene(4);
    }
}
