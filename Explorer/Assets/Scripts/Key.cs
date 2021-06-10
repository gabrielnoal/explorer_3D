using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public int _id;

    public Text legend;
    private bool setText = true;

    private bool gotItem = false;

    public string doorName = "";
    public string keyName = "";
    public GameManager gm;
    public IBaseInventoryItem item;
    public Sprite image;
    public ItemState itemState;

    SceneState sceneState;

    private void Start()
    {
        item = new IBaseInventoryItem();
        gm = GameManager.GetInstance();
        item.name = keyName;
        item.isInteractive = false;
        item.image = image;
        item.doorName = doorName;

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
        itemState.gotItem = gotItem;
        sceneState.setItemStateById(_id, itemState);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (legend && setText && gotItem == false)
        {
            legend.text = "Press E to GET the KEY";
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
