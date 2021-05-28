using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySelector : MonoBehaviour
{

    GameManager gm;

    public List<GameObject> inventoryItems;
    public int lastSelectedItem;

    public int biggestItemIndex;


    // Start is called before the first frame update
    void Start()
    {

        gm = GameManager.GetInstance();
        lastSelectedItem = gm.selectedItem;


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
        if (gm.inventoryChanged)
        {
            if (gm.inventoryItems.Count == 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    GameObject itemImage = GameObject.Find("ItemImage");

                    itemImage.GetComponent<Image>().sprite = null;
                    itemImage.GetComponent<Image>().color = new Color32(38, 38, 38, 255);
                }
            }
            else
            {

                for (int i = 0; i < gm.inventoryItems.Count; i++)
                {

                    GameObject itemImage = GameObject.Find("ItemImage");
                    if (gm.inventoryItems[i].image)
                    {
                        itemImage.GetComponent<Image>().sprite = gm.inventoryItems[i].image;
                        itemImage.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    }
                    else
                    {
                        itemImage.GetComponent<Image>().sprite = null;
                        itemImage.GetComponent<Image>().color = new Color32(38, 38, 38, 255);
                    }
                }
            }


            gm.inventoryChanged = false;
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (gm.selectedItem >= 9)
            {
                gm.selectedItem = 0;
            }
            else
            {

                gm.selectedItem++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (gm.selectedItem <= 0)
            {
                gm.selectedItem = biggestItemIndex;
            }
            else
            {
                gm.selectedItem--;
            }
        }


        if (gm.selectedItem != lastSelectedItem)
        {
            inventoryItems[lastSelectedItem].GetComponent<Image>().color = new Color32(38, 38, 38, 100);
            inventoryItems[gm.selectedItem].GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }

        lastSelectedItem = gm.selectedItem;
    }
}
