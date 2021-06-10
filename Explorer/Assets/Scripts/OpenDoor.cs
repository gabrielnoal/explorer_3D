using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OpenDoor : MonoBehaviour
{
    public int _id;
    public Component door;
    public Animation openDoorAnimation;
    public Text legend;

    public AudioClip openSound;
    public AudioClip lockedSound;

    private bool setText = true;
    public bool isLocked = true;
    public bool canOpenDoor = true;
    public bool keepOpen = true;


    public bool isClosed = true;
    public bool isKeyDoor = true;
    public string MazeScene = "";
    public string doorName = "";

    public GameManager gm;

    public DoorState doorState;

    SceneState sceneState;

    private void Start()
    {
        gm = GameManager.GetInstance();

        sceneState = gm.gs.getStateFromCurrentScene();
        if (sceneState.hasDoorStateById(_id))
        {
            doorState = sceneState.getDoorStateById(_id);
            isClosed = doorState.isClosed;
            isLocked = doorState.isLocked;
            if (!isClosed && !isLocked)
            {
                UnlockDoor();
                if (canOpenDoor)
                {
                    _OpenDoor();
                }
            }
        }
        else
        {
            doorState = new DoorState(isLocked, isClosed);
            sceneState.setDoorStateById(_id, doorState);
        }
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
        Debug.Log(doorName);
        Debug.Log(gm.checkCurrentItem(doorName));
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
        if (keepOpen)
        {
            doorState.isClosed = isClosed;
            sceneState.setDoorStateById(_id, doorState);
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
        doorState.isLocked = isLocked;
        setText = true;
        sceneState.setDoorStateById(_id, doorState);
    }
}
