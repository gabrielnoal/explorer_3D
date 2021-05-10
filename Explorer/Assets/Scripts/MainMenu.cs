using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void PlayGame()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("MazeScene");
    }

    public void ShowOptions()
    {
        GetComponent<AudioSource>().Play();
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        GetComponent<AudioSource>().Play();
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void GoToMenu()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("StartGame");
    }

}
