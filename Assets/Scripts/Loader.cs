using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader{

    public enum Scene{
        Menu,
        Loading,
        Game,
    }

    public static void Load(Scene scene){
        //set callback function in advance to load the target scene
        //load loading scene(WIP)
        //SceneManager.LoadScene(Scene.Loading.ToString());
        SceneManager.LoadScene(scene.ToString());
    }
}
