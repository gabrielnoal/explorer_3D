using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    
    public Component Door;
    public Text legend;
    private bool setText = true;


    void UnlockDoor(){
        Door.GetComponent<OpenDoor>().UnlockDoor();
    }

    private void OnTriggerStay(Collider other) {
        if (setText)
        {
            legend.text = "Press E to GET the KEY";
            setText = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            UnlockDoor();
            ClearText();
            gameObject.SetActive(false);
        }
    }

    void ClearText(){
        if (!setText)
        {
            legend.text = "";
            setText = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        ClearText();
    }
}
