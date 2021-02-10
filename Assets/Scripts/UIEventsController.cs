using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEventsController : MonoBehaviour
{
    // Load Scene
    public void LoadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    // Exit application
    public void ExitApplication()
    {
        Application.Quit();
    }

}
