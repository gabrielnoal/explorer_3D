using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    public GameState gs;

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
        gs = GameState.GetInstance();
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

    public bool checkCurrentItem(string name)
    {
        Debug.Log("Count: " + inventoryItems.Count);
        Debug.Log("selectedItem: " + selectedItem);
        if (selectedItem > inventoryItems.Count - 1)
        {
            return false;
        }
        Debug.Log("inventoryItems[selectedItem].doorName: " + inventoryItems[selectedItem].doorName);
        Debug.Log("inventoryItems[selectedItem].doorName == name: " + inventoryItems[selectedItem].doorName == name);

        if (inventoryItems[selectedItem].doorName != null && inventoryItems[selectedItem].doorName == name)
        {
            return true;
        }
        else
        {
            return false;
        }
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