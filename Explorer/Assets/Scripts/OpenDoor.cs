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

    IEnumerator WaitDoorOpen(){
        yield return new WaitForSeconds(1f);
        door.GetComponent<BoxCollider>().enabled = false;
    }

    void OnTriggerStay()
    {
        if (isClosed && Input.GetKey(KeyCode.E))
        {
            openDoorAnimation.Play();
            StartCoroutine(WaitDoorOpen());
            isClosed = false;
        }
    }
}
