using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class uses for controlling the pause menu functions
public class PauseMenu : MonoBehaviour
{
    //define references
    public GameObject pauseMenu;
    bool isPaused;

    //check for user input on update
    void Update()
    {
        //if user hits escape set flag accordingly 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        //if the game is pause bring up pause menu and pause game
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        //if leaving paused menu disable the menu and unpause the game
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
