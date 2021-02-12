using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//class keeps track of players score by using a timer
//score begins when player passes start and stops when player passes finish line
public class ScoreManager : MonoBehaviour
{
    //define references
    public GameObject start;
    public GameObject finish;
    public TextMeshProUGUI timerScore;
    public GameObject finishScreen;
    CharacterController characterController;
    bool started = false;
    float timer;

    //get the character controller 
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    //start the timer to track player score
    private void Update()
    {
        //if player passes start score being and stops when passing finish line
        if (started)
        {
            timer += Time.deltaTime;

            //format the timer to be neatly displayed on ui
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string time = string.Format("{0:0}:{1:00}", minutes, seconds);

            timerScore.text = time;
        }
    }

    //trigger enter for detecting when player passes go and reaches finish line
    public void OnTriggerEnter(Collider other)
    {
        //if player collides with starting line set flag as true
        if (other.gameObject == start)
        {
            started = true;
        }

        //if player reaches finish line set flag to stop score
        if (other.gameObject == finish)
        {
            started = false;

            //disable player movement and bring up finish screen
            characterController.enabled = false;
            finishScreen.SetActive(true);
        }
    }
}
