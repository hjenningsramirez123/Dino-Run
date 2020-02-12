/*********
 * ChangeScene.cs
 * By: Harry Jennings-Ramirez
 * Last Edited: 2/12/2020
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
        // Opens base game
        GameManager.Resume();
        SceneManager.LoadScene("Game");
    }

    public void OpenGamePlus()
    {
        // Opens plus game
        GameManager.Resume();
        SceneManager.LoadScene("Game+");
    }

    public void CloseGame()
    {
        // Closes game
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        // Takes you back to title screen/menu
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            print("Have escaped");
        }
    }
}
