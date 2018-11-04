using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pInventory : MonoBehaviour {

    private GameObject item;
    public GameObject baseItem;
    private GameObject displayObject;
    // Use this for initialization
    void Start()
    {
        item = baseItem;
    }

    public GameObject getItem()
    {
        return item;
    }
    public void setItem(GameObject newItem)
    {
        item = newItem;

        if (displayObject != null)
        {
            Object.Destroy(displayObject);
        }

        if (newItem.GetComponent<itemType>().myType != itemType.type.NA)
        {
            displayObject = GameObject.Instantiate(item, this.transform, false);
        }
    }
}
