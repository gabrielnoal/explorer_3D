using System.Collections;
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
    public string MazeScene = "";
    public string doorName = "";

    public GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }


    IEnumerator OpenDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        door.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        if (MazeScene != "")
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(MazeScene);
        }

    }

    void OnTriggerStay()
    {
        if (legend && setText)
        {
            legend.text = isLocked ? "Door is locked, find key to open" : "Press E to OPEN the DOOR";
            setText = false;
        }

        if (isClosed && !isLocked && Input.GetKey(KeyCode.E))
        {
            UnlockDoor();
            gm.removeItemFromInventory();
            _OpenDoor();

        }

        if (isClosed && isLocked && Input.GetKey(KeyCode.E) && gm.checkCurrentItem(doorName))
        {
            IBaseInventoryItem current_item = gm.getSelectedItem();

            UnlockDoor();
            gm.removeItemFromInventory();
            _OpenDoor();
        }

        if (isClosed && isLocked && Input.GetKey(KeyCode.E) && !gm.checkCurrentItem(doorName))
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
