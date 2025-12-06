using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButtonScript()
    {
        Application.Quit();
    }

    public void NewGameButtonScript()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }
}
