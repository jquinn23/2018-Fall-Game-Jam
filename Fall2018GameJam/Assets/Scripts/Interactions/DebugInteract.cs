using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInteract : MonoBehaviour {

    private SpriteRenderer rend;
    public Color changeColor;
    public Color currentColor;
    bool isActive;


    void Start ()
    {
        rend = this.GetComponent<SpriteRenderer>();
        currentColor = rend.color;
        isActive = false;
    }

    void OnMouseDown()
    {
        bool interact = false;
        RaycastHit2D northCast = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), .75f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up), Color.green, .75f);

        RaycastHit2D southCast = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), .75f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.green, .75f);

        RaycastHit2D westCast = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.left), .75f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left), Color.green, .75f);

        RaycastHit2D eastCast = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.right), .75f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.green, .75f);

        if (northCast){
            if(northCast.collider.tag.Equals("Player")){
                interact = true;
            }
        }
        if (southCast){
            if (southCast.collider.tag.Equals("Player")){
                interact = true;
            }
        }

        if (westCast){
            if (westCast.collider.tag.Equals("Player")){
                interact = true;
            }
        }
        if (eastCast){
            if (eastCast.collider.tag.Equals("Player")){
                interact = true;
            }
        }

        if (interact){
            if (!isActive){
                rend.color = changeColor;
                isActive = true;
            }
            else{
                rend.color = currentColor;
                isActive = false;
            }
        }
    }
}
