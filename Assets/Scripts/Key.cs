using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for key objects that player needs to pick up to open doors
public class Key : MonoBehaviour
{
    //define references
    GameObject player;
    public GameObject wall;

    //get the player gameobject
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //roate the key on its y axis to make it appear as spinning
    private void Update()
    {
        transform.Rotate(0, 0.5f, 0);
    }

    //trigger event for detecting when player finds key
    public void OnTriggerEnter(Collider other)
    {
        //if player collides with key open the corresponding door
        if (other.gameObject == player)
        {
            OpenDoor();
        }
    }

    //function used to rotate the corresponding door open
    void OpenDoor()
    {
        wall.transform.Rotate(0, -90, 0);
        gameObject.SetActive(false); //remove key object from scene
    }
}
