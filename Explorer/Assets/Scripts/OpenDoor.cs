﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OpenDoor : MonoBehaviour
{

    public Component door;
    public Animation openDoorAnimation;
    public Text legend;

    public AudioClip openSound;
    public AudioClip lockedSound;

    private bool setText = true;
    public bool isLocked = true;

    private bool isClosed = true;
    public bool isKeyDoor = true;
    public string MazeScene = "";
    public string doorName = "";

    public GameManager gm;


    private void Start()
    {
        gm = GameManager.GetInstance();
    }


    IEnumerator OpenDoorRoutine()
    {

        if (MazeScene != "")
        {

            switch (MazeScene)
            {

                case "Maze1":
                    gm.gs.setPosition(-1.564f, 9.605f);
                    gm.gs.setRotation(64f);
                    break;
                case "Maze2":
                    gm.gs.setPosition(-1.564f, 11.469f);
                    gm.gs.setRotation(117f);
                    break;
                case "Maze3":
                    gm.gs.setPosition(-0.023f, 12.122f);
                    gm.gs.setRotation(173f);
                    break;
                case "Maze4":
                    gm.gs.setPosition(1.408f, 11.2f);
                    gm.gs.setRotation(-143f);
                    break;
                case "Maze5":
                    gm.gs.setPosition(1.408f, 9.328f);
                    gm.gs.setRotation(-54f);
                    break;
                default:
                    break;

            }
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(MazeScene);
        }
        yield return new WaitForSeconds(1f);
        door.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

    }

    void OnTriggerStay()
    {
        if (legend && setText)
        {
            if (isLocked)
            {
                legend.text = isKeyDoor ? "Door is locked, find KEY to open" : "Door is locked, find the PASSWORD to open";
            }
            else
            {
                legend.text = "Press E to OPEN the DOOR";
            }
            setText = false;
        }

        if (isClosed && !isLocked && Input.GetKey(KeyCode.E))
        {
            UnlockDoor();
            _OpenDoor();
        }

        else if (isClosed && isLocked && Input.GetKey(KeyCode.E) && gm.checkCurrentItem(doorName))
        {
            IBaseInventoryItem current_item = gm.getSelectedItem();

            UnlockDoor();
            gm.removeItemFromInventory();
            _OpenDoor();
        }

        else if (isClosed && isLocked && Input.GetKey(KeyCode.E) && !gm.checkCurrentItem(doorName))
        {
            GetComponent<AudioSource>().clip = lockedSound;
            GetComponent<AudioSource>().Play();
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

    public void _OpenDoor()
    {
        GetComponent<AudioSource>().clip = openSound;
        GetComponent<AudioSource>().Play();
        openDoorAnimation.Play();
        StartCoroutine(OpenDoorRoutine());
        isClosed = false;
    }

    public void UnlockDoor()
    {
        isLocked = false;
        setText = true;
    }
}
