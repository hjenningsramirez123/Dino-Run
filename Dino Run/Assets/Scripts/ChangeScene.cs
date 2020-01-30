﻿/*********
 * ChangeScene.cs
 * By: Harry Jennings-Ramirez
 * Last Edited: 1/30/2020
 * Description: Changes scene when needed 
 ********/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
