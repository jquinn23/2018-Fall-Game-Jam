using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveInteract : MonoBehaviour {
    private GameControl controller;
    private GameObject player;
    private bool interact;
    public float spawnDistance;

    //Zombie Types
    public GameObject baseItem;
    public GameObject redZombie;
    public GameObject blueZombie;
    public GameObject greenZombie;
    public GameObject redBlueZombie;
    public GameObject redGreenZombie;
    public GameObject blueGreenZombie;
    public GameObject redBlueGreenZombie;

    // Use this for initialization
    void Start () {
        controller = GameObject.Find("GameManager").GetComponent<GameControl>();
        player = GameObject.Find("Player");
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
            if(heldItemType.myType == itemType.type.R)
            {
                GameObject.Instantiate(redZombie, this.transform.position + new Vector3(spawnDistance, 0, 0), new Quaternion(0, 0, 0, 0));
            }
            else if(heldItemType.myType == itemType.type.B)
            {
                GameObject.Instantiate(blueZombie, this.transform.position + new Vector3(spawnDistance, 0, 0), new Quaternion(0, 0, 0, 0));
            }
            else if(heldItemType.myType == itemType.type.G)
            {
                GameObject.Instantiate(greenZombie, this.transform.position + new Vector3(spawnDistance, 0, 0), new Quaternion(0, 0, 0, 0));
            }
            else if(heldItemType.myType == itemType.type.RG)
            {
                GameObject.Instantiate(redGreenZombie, this.transform.position + new Vector3(spawnDistance, 0, 0), new Quaternion(0, 0, 0, 0));
            }
            else if (heldItemType.myType == itemType.type.RB)
            {
                GameObject.Instantiate(redBlueZombie, this.transform.position + new Vector3(spawnDistance, 0, 0), new Quaternion(0, 0, 0, 0));
            }
            else if (heldItemType.myType == itemType.type.BG)
            {
                GameObject.Instantiate(blueGreenZombie, this.transform.position + new Vector3(spawnDistance, 0, 0), new Quaternion(0, 0, 0, 0));
            }
            else if (heldItemType.myType == itemType.type.RGB)
            {
                GameObject.Instantiate(redBlueGreenZombie, this.transform.position + new Vector3(spawnDistance,0,0), new Quaternion(0,0,0,0));
            }

            player.GetComponent<pInventory>().setItem(baseItem);
        }
    }
}
