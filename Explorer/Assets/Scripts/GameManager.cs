using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// public class ILetterItem
// {
//     public string text { get; set; }
// }

// public class IKeyItem
// {
//     public string doorName { get; set; }
// }

public interface KeyItem
{
    string doorName { get; set; }
}

public interface LetterItem
{
    string letterText { get; set; }
}

public class IBaseInventoryItem : LetterItem, KeyItem
{
    public string name { get; set; }
    public bool isInteractive { get; set; }
    public Sprite image { get; set; }

    public string doorName { get; set; }

    public string letterText { get; set; }

}

public class GameManager
{

    public List<IBaseInventoryItem> inventoryItems;

    private static GameManager _instance;

    public bool inventoryChanged;

    public int selectedItem;

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
        inventoryItems = new List<IBaseInventoryItem>();
        inventoryChanged = false;
        selectedItem = 0;
    }

    public void inventoryItemsChanged()
    {
        inventoryChanged = true;
    }

    public void addItemToInventory(IBaseInventoryItem item)
    {
        inventoryItems.Add(item);
        inventoryItemsChanged();
    }

    public void removeItemFromInventory()
    {
        List<IBaseInventoryItem> newList = new List<IBaseInventoryItem>();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i] != null && selectedItem != i)
            {
                newList.Add(inventoryItems[i]);
            }
        }

        inventoryItems = newList;
        inventoryItemsChanged();
    }

    public IBaseInventoryItem getSelectedItem()
    {
        return inventoryItems[selectedItem];
    }

}