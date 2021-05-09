using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{

    public Component door;
    public Animation openDoorAnimation;
    public Text legend;

    private bool setText = true;
    public bool isLocked = true;

    private bool isClosed = true;

    IEnumerator OpenDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        door.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

    }

    void OnTriggerStay()
    {
        if (setText)
        {
            legend.text = isLocked ? "Door is locked, find key to open" : "Press E to OPEN the DOOR";
            setText = false;
            
        }
        if (isClosed && !isLocked && Input.GetKey(KeyCode.E))
        {
            openDoorAnimation.Play();
            StartCoroutine(OpenDoorRoutine());
            isClosed = false;
        }
    }

    void ClearText()
    {
        if (!setText)
        {
            legend.text = "";
            setText = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ClearText();
    }

    public void UnlockDoor()
    {
        isLocked = false;
        setText = true;
    }
}
