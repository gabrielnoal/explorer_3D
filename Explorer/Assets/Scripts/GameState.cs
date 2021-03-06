using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorState
{
    public bool isLocked;
    public bool isClosed;

    public DoorState(bool Locked, bool Closed)
    {
        isLocked = Locked;
        isClosed = Closed;
    }
}

public class ChestState
{
    public bool isOpen;

    public ChestState(bool _isOpen)
    {
        isOpen = _isOpen;
    }
}

public class ItemState
{
    public bool gotItem;

    public ItemState(bool _gotItem)
    {
        gotItem = _gotItem;
    }
}

public class SceneState
{
    public Dictionary<int, DoorState> doors = new Dictionary<int, DoorState>();
    public Dictionary<int, ChestState> chests = new Dictionary<int, ChestState>();
    public Dictionary<int, ItemState> items = new Dictionary<int, ItemState>();

    public bool hasDoorStateById(int id)
    {
        return doors.ContainsKey(id);
    }

    public DoorState getDoorStateById(int id)
    {
        return doors[id];
    }

    public DoorState setDoorStateById(int id, DoorState newState)
    {
        if (hasDoorStateById(id))
        {
            doors[id] = newState;
        } else {
            doors.Add(id,newState);
        }
        return doors[id];
    }

    public bool hasChestStateById(int id)
    {
        return chests.ContainsKey(id);
    }

    public ChestState getChestStateById(int id)
    {
        return chests[id];
    }

    public ChestState setChestStateById(int id, ChestState newState)
    {
        if (hasChestStateById(id))
        {
            chests[id] = newState;
        } else {
            chests.Add(id,newState);
        }
        return chests[id];
    }

    public bool hasItemStateById(int id)
    {
        return items.ContainsKey(id);
    }

    public ItemState getItemStateById(int id)
    {
        return items[id];
    }

    public ItemState setItemStateById(int id, ItemState newState)
    {
        if (hasItemStateById(id))
        {
            items[id] = newState;
        } else {
            items.Add(id,newState);
        }
        return items[id];
    }
}

public class GameState
{

    private static GameState _instance;

    private SceneState LobbyState = new SceneState();
    private SceneState Maze1State = new SceneState();
    private SceneState Maze2State = new SceneState();
    private SceneState Maze3State = new SceneState();
    private SceneState Maze4State = new SceneState();
    private SceneState Maze5State = new SceneState();

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

    public SceneState getStateFromCurrentScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "LobbyScene":
                return LobbyState;
            case "Maze1":
                return Maze1State;
            case "Maze2":
                return Maze2State;
            case "Maze3":
                return Maze3State;
            case "Maze4":
                return Maze4State;
            case "Maze5":
                return Maze5State;
            default:
                return null;
        }
    }
}