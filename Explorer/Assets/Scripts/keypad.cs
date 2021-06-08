//333333333333333333333333333333333333333333333333333333333333333333\\
//
//          Arthur: Cato Parnell
//          Description of script: control keypad button clicks and actions
//          Any queries please go to Youtube: Cato Parnell and ask on video. 
//          Thanks.
//
//33333333333333333333333333333333333333333333333333333333333333333\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad : MonoBehaviour
{

    public Text legend;
    private bool setText = true;
    // *** CAN DELETE THESE ** \\
    // Used to hide joystick and slider
    [Header("Objects to Hide/Show")]
    public GameObject objectToDisable;
    public GameObject objectToDisable2;

    // Object to be enabled is the keypad. This is needed
    public GameObject objectToEnable;
    public GameObject door;

    // *** Breakdown of header(public) variables *** \\
    // curPassword : Pasword to set. Ive set the password in the project. Note it can be any length and letters or numbers or sysmbols
    // input: What is currently entered
    // displayText : Text area on keypad the password entered gets displayed too.
    // audioData : Play this sound when user enters in password incorrectly too many times

    [Header("Keypad Settings")]
    public string curPassword = "1234";
    public string input;
    public Text displayText;
    public AudioSource audioData;

    //Local private variables
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length.
        audioData = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                DisabeBoxCollider();
                CloseKeypad();
                OpenDoor();
            }
            else
            {
                ResetInput();
                audioData.Play();
            }

        }
    }

    public void DisabeBoxCollider()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void OpenDoor()
    {
        door.GetComponent<OpenDoor>().UnlockDoor();
        door.GetComponent<OpenDoor>()._OpenDoor();
    }



    private void OnTriggerStay(Collider other)
    {
        if (legend && setText && !keypadScreen)
        {
            legend.text = "Press E to OPEN KEYPAD";
            setText = false;
        }
        if (Input.GetKey(KeyCode.E) && !keypadScreen)
        {
            OpenKeypad();
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
        // Disable sections when keypadScreen is set to true
        if (Input.GetKey(KeyCode.E) && keypadScreen)
        {
            CloseKeypad();
        }
        ClearText();
    }

    public void ResetInput()
    {
        //Reset input varible
        input = "";
        displayText.text = input.ToString();
        btnClicked = 0;
    }

    public void OpenKeypad()
    {
        ClearText();
        player.GetComponent<PlayerController>().playerCanMove = false;
        keypadScreen = true;
        objectToDisable.SetActive(false);
        objectToDisable2.SetActive(false);
        objectToEnable.SetActive(true);
    }

    public void CloseKeypad()
    {
        print("close");
        objectToDisable.SetActive(true);
        objectToDisable2.SetActive(true);
        objectToEnable.SetActive(false);
        keypadScreen = false;
        //player.GetComponent<PlayerController>().playerCanMove = true;
        ResetInput();
    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
                CloseKeypad();
                break;

            case "C": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}
