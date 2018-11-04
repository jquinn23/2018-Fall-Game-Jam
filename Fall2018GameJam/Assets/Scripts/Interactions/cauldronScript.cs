using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cauldronScript : MonoBehaviour {

    public GameObject baseItem;
    public GameObject containedItem;
    private GameControl controller;
    private GameObject player;
    private bool interact;


    public GameObject RedPotion;
    public GameObject GreenPotion;
    public GameObject BluePotion;
    public GameObject RedBluePotion;
    public GameObject RedGreenPotion;
    public GameObject BlueGreenPotion;
    public GameObject RedBlueGreenPotion;
    public GameObject Bubbles;

    private void Start()
    {
        controller = GameObject.Find("GameManager").GetComponent<GameControl>();
        player = controller.getPlayer();
        containedItem = baseItem;
        interact = false;
        Bubbles.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            interact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            interact = false;
        }
    }

    void OnMouseDown()
    {
        
        if (interact)
        {
            itemType heldItemType = player.GetComponent<pInventory>().getItem().GetComponent<itemType>();
            if (heldItemType.myType != itemType.type.NA)
            {
                if (containedItem.GetComponent<itemType>().myType == itemType.type.R)
                {
                    if (heldItemType.myType == itemType.type.B || heldItemType.myType == itemType.type.RB)
                    {
                        containedItem = RedBluePotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 0, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.G || heldItemType.myType == itemType.type.RG)
                    {
                        containedItem = RedGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 0);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.BG || heldItemType.myType == itemType.type.RGB)
                    {
                        containedItem = RedBlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
                        Bubbles.SetActive(true);
                    }
                }
                else if (containedItem.GetComponent<itemType>().myType == itemType.type.B)
                {
                    if (heldItemType.myType == itemType.type.R || heldItemType.myType == itemType.type.RB)
                    {
                        containedItem = RedBluePotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 0, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.G || heldItemType.myType == itemType.type.BG)
                    {
                        containedItem = BlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(0, 255f, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.RG || heldItemType.myType == itemType.type.RGB)
                    {
                        containedItem = RedBlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
                        Bubbles.SetActive(true);
                    }
                }
                else if (containedItem.GetComponent<itemType>().myType == itemType.type.G)
                {
                    if (heldItemType.myType == itemType.type.R || heldItemType.myType == itemType.type.RG)
                    {
                        containedItem = RedGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 0);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.B || heldItemType.myType == itemType.type.BG)
                    {
                        containedItem = BlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(0, 255f, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.RB || heldItemType.myType == itemType.type.RGB)
                    {
                        containedItem = RedBlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
                        Bubbles.SetActive(true);
                    }
                }
                else if (containedItem.GetComponent<itemType>().myType == itemType.type.RB)
                {
                    if (heldItemType.myType == itemType.type.R || heldItemType.myType == itemType.type.B)
                    {
                        containedItem = RedBluePotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 0, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.G || heldItemType.myType == itemType.type.RG || heldItemType.myType == itemType.type.BG || heldItemType.myType == itemType.type.RGB)
                    {
                        containedItem = RedBlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
                        Bubbles.SetActive(true);
                    }

                }
                else if (containedItem.GetComponent<itemType>().myType == itemType.type.RG)
                {
                    if (heldItemType.myType == itemType.type.R || heldItemType.myType == itemType.type.G)
                    {
                        containedItem = RedGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 0);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.B || heldItemType.myType == itemType.type.RB || heldItemType.myType == itemType.type.BG || heldItemType.myType == itemType.type.RGB)
                    {
                        containedItem = RedBlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
                        Bubbles.SetActive(true);
                    }

                }
                else if (containedItem.GetComponent<itemType>().myType == itemType.type.BG)
                {
                    if (heldItemType.myType == itemType.type.B || heldItemType.myType == itemType.type.G)
                    {
                        containedItem = BlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(0, 255f, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.R || heldItemType.myType == itemType.type.RB || heldItemType.myType == itemType.type.RG || heldItemType.myType == itemType.type.RGB)
                    {
                        containedItem = RedBlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
                        Bubbles.SetActive(true);
                    }

                }
                else if (containedItem.GetComponent<itemType>().myType == itemType.type.NA)
                {
                    if (heldItemType.myType == itemType.type.R)
                    {
                        containedItem = RedPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 0, 0);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.B)
                    {
                        containedItem = BluePotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.G)
                    {
                        containedItem = GreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(0, 255f, 0);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.RG)
                    {
                        containedItem = RedGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 0);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.RB)
                    {
                        containedItem = RedBluePotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 0, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.BG)
                    {
                        containedItem = RedBlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
                        Bubbles.SetActive(true);
                    }
                    else if (heldItemType.myType == itemType.type.RGB)
                    {
                        containedItem = RedBlueGreenPotion;
                        Bubbles.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
                        Bubbles.SetActive(true);
                    }
                }

                player.GetComponent<pInventory>().setItem(baseItem);
            }
            else
            {
                player.GetComponent<pInventory>().setItem(containedItem);
                Bubbles.SetActive(false);
                containedItem = baseItem;
            }
        }
        }
    }
