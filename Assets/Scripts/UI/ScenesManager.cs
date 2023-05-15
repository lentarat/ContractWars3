using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager
{
    private ScenesManager() { }

    private static ScenesManager _instance;
    public static ScenesManager Instance 
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new ScenesManager();
            }
            return _instance;
        }    
    }

    public enum Scene
    {
        MainMenu,
        Map
    }

    public void LoadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Scene.Map.ToString());
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
}
