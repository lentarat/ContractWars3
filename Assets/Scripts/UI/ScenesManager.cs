using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    public enum Scene
    {
        MainMenu,
        Map
    }

    private void Awake()
    {
        Instance = this;
    }

    //public void LoadScene(Scene scene)
    //{
    //    SceneManager.LoadScene(scene.ToString());
    //}

    public void LoadMap()
    {
        SceneManager.LoadScene(Scene.Map.ToString());
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
}
