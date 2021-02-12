using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

//class used to get name entry from player and sort score into leaderboard
public class PlayerEntry : MonoBehaviour
{
    //define references
    public TextMeshProUGUI timerScore;
    public GameObject inputField;
    string nameEntry;
    Dictionary<string, int> leaderboard = new Dictionary<string, int>();

    //function used for getting name entry and adding it to leaderboards
    public void SubmitScoreAndName()
    {
        //default name if no name is entered
        string name = "???";
        nameEntry = inputField.GetComponent<TMP_InputField>().text;

        if (!string.IsNullOrEmpty(nameEntry))
        {
            name = nameEntry;
        }

        string score = timerScore.text;
        string entry = name + " - " + score;

        //write the name entry will player score to leaderboard and change the scene to the leaderboard scene
        WriteToFile(entry);
        SceneManager.LoadScene("Leaderboard");
    }

    //function reads txt file, adds bew entry and sorts the updated scores
    void WriteToFile(string entry)
    {
        string path = Application.dataPath + "/leaderboard.txt";

        //if file does not exist create the file and add the entry
        if (!File.Exists(path))
        {
            File.WriteAllText(path, entry + "\n");
        }
        else
        {
            //add the entry to the end of file
            File.AppendAllText(path, entry + "\n");

            //read each entry and sort since new entry has been added
            foreach(string line in File.ReadAllLines(path))
            {
                //parse string to get the score value and convert to an integer value
                string score = line.Substring(line.LastIndexOf('-') + 1).Replace(":", string.Empty).Replace(" ", string.Empty);
                int result = Int32.Parse(score);

                //if entry is a not a duplicate at it to the dictionary and use score value as the key
                if (!leaderboard.ContainsKey(line))
                {
                    leaderboard.Add(line, result);
                }
            }

            //create a new dictionary sorted by key value
            var sortedDict = leaderboard.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            
            //read each entry in the sorted dictionary and add to string
            string newEntries = string.Empty;
            foreach(var player in sortedDict)
            {
                newEntries += player.Key + "\n";
            }

            //write the string value to the file replacing all older lines
            File.WriteAllText(path, newEntries);
        }
    }
}
