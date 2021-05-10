using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CountDown : MonoBehaviour
{

    public float totalTime;

    public Text text;

    public float minutes;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;

        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);

        if (seconds < 10)
        {
            text.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            text.text = "0" + minutes.ToString() + ":" + seconds.ToString();
        }

        if (minutes <= 0 && seconds <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("LoseScene");
        }
    }
}
