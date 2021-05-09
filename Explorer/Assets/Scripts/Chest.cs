using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animation openChestAnimation;
    public Animation keyAnimation;
    public Component key;

    private bool opened;
    void Start()
    {
        opened = false;
    }

    IEnumerator WaitChestOpen(){
        yield return new WaitForSeconds(1.5f);
        key.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerStay(Collider other) {
        if (opened == false && Input.GetKey(KeyCode.E))
        {
            openChestAnimation.Play();
            keyAnimation.Play();
            StartCoroutine(WaitChestOpen());
            opened = true;
        }
    }
}
