using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{

    public int _id;

    public Text legend;
    private bool setText = true;

    private bool gotItem = false;

    public string itemName = "";
    public GameManager gm;
    public IBaseInventoryItem item;
    public Sprite image;
    public string letterText;

    public ItemState itemState;

    SceneState sceneState;

    private void Start()
    {
        item = new IBaseInventoryItem();
        gm = GameManager.GetInstance();
        item.name = itemName;
        item.isInteractive = true;
        item.image = image;
        item.letterText = letterText;

        sceneState = gm.gs.getStateFromCurrentScene();
        if (sceneState.hasItemStateById(_id))
        {
            itemState = sceneState.getItemStateById(_id);
            gotItem = itemState.gotItem;
            if (gotItem)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            itemState = new ItemState(gotItem);
            sceneState.setItemStateById(_id, itemState);
        }
    }

    IEnumerator WaitSoundPlay()
    {
        yield return new WaitForSeconds(.25f);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (legend && setText && gotItem == false)
        {
            legend.text = "Press E to GET the Letter";
            setText = false;
        }
        if (Input.GetKey(KeyCode.E) && gotItem == false)
        {
            gotItem = true;
            GetComponent<AudioSource>().Play();
            gm.addItemToInventory(item);
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
