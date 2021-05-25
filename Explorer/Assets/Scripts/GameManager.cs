using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IInventoryItem
{
    string name { get; set; }
    bool isInteractive { get; set; }
    string imagePath { get; set; }
}

public class GameManager
{

    public List<IInventoryItem> inventoryItems;

    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        inventoryItems = new List<IInventoryItem>();
    }


}