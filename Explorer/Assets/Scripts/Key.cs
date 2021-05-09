using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    
    public Component Door;

    void UnlockDoor(){
        Door.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerStay(Collider other) {
        if (Input.GetKey(KeyCode.E))
        {
            UnlockDoor();
            gameObject.SetActive(false);
        }
    }
}
