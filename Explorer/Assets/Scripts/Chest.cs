using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public int _id;

    public Animation openChestAnimation;
    public Animation itemAnimation;
    public Component item;
    public Text legend;

    private bool isOpen = false;
    private bool setText = true;

    public GameManager gm;
    public ChestState chestState;

    SceneState sceneState;
    void Start()
    {
        gm = GameManager.GetInstance();

        sceneState = gm.gs.getStateFromCurrentScene();
        if (sceneState.hasChestStateById(_id))
        {
            chestState = sceneState.getChestStateById(_id);
            isOpen = chestState.isOpen;
            if (isOpen)
            {
                openChestAnimation.Play();
                itemAnimation.Play();

            }
        }
        else
        {
            chestState = new ChestState(isOpen);
            sceneState.setChestStateById(_id, chestState);
        }
    }

    IEnumerator WaitChestOpen()
    {
        yield return new WaitForSeconds(1.5f);
        item.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (legend && !isOpen && setText)
        {
            legend.text = "Press E to OPEN the CHEST";
            setText = false;
        }
        if (!isOpen && Input.GetKey(KeyCode.E))
        {
            ClearText();
            GetComponent<AudioSource>().Play();
            openChestAnimation.Play();
            itemAnimation.Play();
            StartCoroutine(WaitChestOpen());
            isOpen = true;
            chestState.isOpen = isOpen;
            sceneState.setChestStateById(_id, chestState);
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
