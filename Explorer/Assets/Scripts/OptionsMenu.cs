using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public GameObject mainMenu;
    IEnumerator WaitSoundPlay()
    {
        yield return new WaitForSeconds(.1f);
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(WaitSoundPlay());
    }

}
