using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//class for controlling the menu options within scences
public class MenuController : MonoBehaviour
{
    //function loads maze runner game
    public void StartGame()
    {
        SceneManager.LoadScene("MazeRunner");
    }

    //function quits the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //function quits the maze runner scene and loads menu scene
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //function loads the leaderboard scene
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
