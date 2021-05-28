using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public Component Door;
    public Text legend;
    private bool setText = true;

    private bool gotKey = false;

    IEnumerator WaitSoundPlay()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }

    void UnlockDoor()
    {
        Door.GetComponent<OpenDoor>().UnlockDoor();
    }

    private void OnTriggerStay(Collider other)
    {
        if (legend && setText && gotKey == false)
        {
            legend.text = "Press E to GET the KEY";
            setText = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            gotKey = true;
            GetComponent<AudioSource>().Play();
            UnlockDoor();
            ClearText();
            StartCoroutine(WaitSoundPlay());
        }
    }

    void ClearText()
    {
        if (legend && !setText)
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
