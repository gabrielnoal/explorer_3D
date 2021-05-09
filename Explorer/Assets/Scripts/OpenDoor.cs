using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    public Component door;
    public Animation openDoorAnimation;
    private bool isClosed;
    void Start()
    {
        isClosed = true;
    }

    void OnTriggerStay()
    {
        if (isClosed && Input.GetKey(KeyCode.E))
        {
            door.GetComponent<BoxCollider>().enabled = false;
            openDoorAnimation.Play();
            isClosed = false;
        }
    }
}
