using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{

    public Text legend;
    private bool setText = true;

    private bool gotKey = false;

    public string itemName = "";
    public GameManager gm;
    public IInventoryItem item;
    public Sprite image;
    public string letterText;

    private void Start() {
        gm = GameManager.GetInstance();
        item.name = itemName;
        item.isInteractive = true;
        item.image = image;
        item.letter.text = letterText;
    }

    IEnumerator WaitSoundPlay()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
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
            //UnlockDoor();
            //gm.addItemToInventory(item)
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
