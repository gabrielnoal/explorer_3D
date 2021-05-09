using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animation openChestAnimation;
    public Component hinge;

    private bool opened;
    void Start()
    {
        opened = false;
    }

    private void OnTriggerStay(Collider other) {
        if (opened == false && Input.GetKey(KeyCode.E))
        {
            hinge.GetComponent<BoxCollider>().enabled = true;
            openChestAnimation.Play();
            opened = true;
        }
    }
}
