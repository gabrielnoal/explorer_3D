using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState
{

    private static GameState _instance;

    public float x_position;
    public float y_position;
    public float z_position;

    public float y_rotation;


    public static GameState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameState();
        }
        return _instance;
    }

    private GameState()
    {
        x_position = 1;
        y_position = 0.78f;
        z_position = -3;
        y_rotation = 0;
    }

    public void setPosition(float pos_x, float pos_z)
    {
        x_position = pos_x;
        z_position = pos_z;
    }

    public void setRotation(float rot_y)
    {
        y_rotation = rot_y;
    }

}