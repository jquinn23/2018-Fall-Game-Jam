using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public int health;
    public float castDistance;
    public int attackDamage;
    public float attackSpeed;
    public float speed;
    private bool opake;
    private bool attackFlag;
	// Use this for initialization
	void Start () {
        attackFlag = false;
        InvokeRepeating("canAttack", 0, attackSpeed);
        InvokeRepeating("blink", 0, .2f);
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D westCast = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.left), .75f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left), Color.green, .75f);

        if(westCast)
        {
            if (westCast.collider.tag.Equals("Minion"))
            {
                if (attackFlag)
                {
                    westCast.collider.GetComponent<MeleeMinionScript>().takeDamage(attackDamage);
                    attackFlag = false;
                }
            }
            else if (westCast.collider.tag.Equals("GraveStone"))
            {
                GameObject.Find("GameManager").GetComponent<GameControl>().EndLevel();
            }
            else
            {
                Debug.Log(westCast.collider.tag);
            }
        }
        else
        {
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, 0);
        if (health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void blink()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, 1);
    }

    void canAttack()
    {
        attackFlag = true;
    }
}
