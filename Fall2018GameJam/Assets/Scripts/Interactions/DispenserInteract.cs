using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenserInteract : MonoBehaviour {
    public GameObject dispenseItem;
    private GameControl controller;
    private GameObject player;
    private bool interact;

    private void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameControl>();
        player = controller.getPlayer();
        interact = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            interact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            interact = false;
        }
    }

    void OnMouseDown()
    {
        if (interact)
        {
            itemType heldItemType = player.GetComponent<pInventory>().getItem().GetComponent<itemType>();
            if(heldItemType.myType == itemType.type.NA)
            {
                Debug.Log("Dispensed");
                player.GetComponent<pInventory>().setItem(dispenseItem);
            }
            else
            {
                Debug.Log("Don't Dispense");
            }   
        }
    }
}
