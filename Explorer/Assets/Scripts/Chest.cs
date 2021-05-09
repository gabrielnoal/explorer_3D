using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Animation openChestAnimation;
    public Animation keyAnimation;
    public Component key;
    public Text legend;

    private bool opened;
    private bool setText = true;
    void Start()
    {
        opened = false;
    }

    IEnumerator WaitChestOpen()
    {
        yield return new WaitForSeconds(1.5f);
        key.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!opened && setText)
        {
            legend.text = "Press E to OPEN the CHEST";
            setText = false;
        }
        if (!opened && Input.GetKey(KeyCode.E))
        {
            ClearText();
            openChestAnimation.Play();
            keyAnimation.Play();
            StartCoroutine(WaitChestOpen());
            opened = true;
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
}
