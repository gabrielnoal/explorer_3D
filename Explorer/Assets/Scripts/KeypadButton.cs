using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public GameObject keypad;
    private float timestamp = 0f;
    public float InputRate = 0.25f;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > timestamp)
        {

            if (Input.GetKey(KeyCode.Keypad0) || Input.GetKey(KeyCode.Alpha0))
            {
                ClickButton("0");
            }
            else if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
            {
                ClickButton("1");
            }
            else if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
            {
                ClickButton("2");
            }
            else if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
            {
                ClickButton("3");
            }
            else if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Alpha4))
            {
                ClickButton("4");
            }
            else if (Input.GetKey(KeyCode.Keypad5) || Input.GetKey(KeyCode.Alpha5))
            {
                ClickButton("5");
            }
            else if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.Alpha6))
            {
                ClickButton("6");
            }
            else if (Input.GetKey(KeyCode.Keypad7) || Input.GetKey(KeyCode.Alpha7))
            {
                ClickButton("7");
            }
            else if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.Alpha8))
            {
                ClickButton("8");
            }
            else if (Input.GetKey(KeyCode.Keypad9) || Input.GetKey(KeyCode.Alpha9))
            {
                ClickButton("9");
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                ClickButton("Q");
            }
            else if (Input.GetKey(KeyCode.C))
            {
                ClickButton("C");
            }
        }
    }

    public void ClickButton(string value)
    {
        keypad.GetComponent<keypad>().ValueEntered(value);
        gameObject.GetComponent<AudioSource>().Play();
        timestamp = Time.time + InputRate;
    }
}
