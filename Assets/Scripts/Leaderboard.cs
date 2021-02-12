using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//class used for reading the leaderboard txt file and displaying it in ui
public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI leaderboard;
    private void Awake()
    {
        string path = Application.dataPath + "/leaderboard.txt";

        //if the leaderboard file exists get the string and set as ui text
        if (File.Exists(path))
        {
            string entries = File.ReadAllText(path);
            leaderboard.text = entries;
        }
    }

    //function used for returning to the menu from the leaderboard scene
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
