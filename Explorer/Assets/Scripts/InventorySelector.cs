using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySelector : MonoBehaviour
{
    public List<GameObject> inventoryItems;
    public int lastSelectedItem;

    public int selectedItem;

    public int biggestItemIndex;


    // Start is called before the first frame update
    void Start()
    {
        selectedItem = 0;
        lastSelectedItem = 0;


        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("InventoryItem"))
        {
            inventoryItems.Add(obj.gameObject);
        }

        biggestItemIndex = inventoryItems.Count - 1;
        inventoryItems[0].GetComponent<Image>().color = new Color32(255, 255, 255, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (selectedItem >= 9)
            {
                selectedItem = 0;
            }
            else
            {

                selectedItem++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (selectedItem <= 0)
            {
                selectedItem = biggestItemIndex;
            }
            else
            {
                selectedItem--;
            }
        }

        print(selectedItem);

        if (selectedItem != lastSelectedItem)
        {
            inventoryItems[lastSelectedItem].GetComponent<Image>().color = new Color32(38, 38, 38, 100);
            inventoryItems[selectedItem].GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }

        lastSelectedItem = selectedItem;
    }
}
