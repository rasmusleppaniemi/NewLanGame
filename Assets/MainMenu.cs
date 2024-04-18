using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene("Map1");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
