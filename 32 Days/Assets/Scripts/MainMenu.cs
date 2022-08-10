using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SetScene(int sceneIndex) // will be executed by a level button
    {
        SceneManager.LoadScene(sceneIndex); // loads scene of choice
    }

    public void QuitScene() // called by quit button
    {
        Application.Quit(); // quits game
    }
}
