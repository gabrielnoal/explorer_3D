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

    public bool isFirstDoor = false;

    public bool isLastDoor = false;
    public GameObject countdown;

    private bool isClosed = true;
    public string MazeScene = "";

    IEnumerator OpenDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        door.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        if(MazeScene != "") {
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
        if (isClosed && isLocked && Input.GetKey(KeyCode.E))
        {
            GetComponent<AudioSource>().clip = lockedSound;
            GetComponent<AudioSource>().Play();
        }
        if (isClosed && !isLocked && Input.GetKey(KeyCode.E))
        {

            GetComponent<AudioSource>().clip = openSound;
            GetComponent<AudioSource>().Play();
            openDoorAnimation.Play();
            StartCoroutine(OpenDoorRoutine());
            isClosed = false;
            if (isFirstDoor)
            {
                countdown.SetActive(true);
            }
            if (isLastDoor)
            {
                SceneManager.LoadScene("WinScene");
            }
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

    public void UnlockDoor()
    {
        isLocked = false;
        setText = true;
    }
}
