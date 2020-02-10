/*********
 * ChangeScene.cs
 * By: Harry Jennings-Ramirez
 * Last Edited: 2/6/2020
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

    public void ExitGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            print("Have escaped");
        }
    }

    public void OpenGame()
    {
        GameManager.Resume();
        SceneManager.LoadScene("Game");
    }

    public void OpenGamePlus()
    {
        GameManager.Resume();
        SceneManager.LoadScene("Game+");
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
