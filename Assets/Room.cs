using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D Room)
    {
        if(Room.CompareTag("Player") && !Room.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D Room)
    {
        if (Room.CompareTag("Player") && !Room.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
}
