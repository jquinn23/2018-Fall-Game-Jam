using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMinionScript : MonoBehaviour {
    public float speed;
    public int attackDamage;
    public float attackSpeed;
    public int health;
    public float castLength;
    private bool attackFlag;
	// Use this for initialization
	void Start () {
        InvokeRepeating("canAttack", 0, attackSpeed);
        InvokeRepeating("blink", 0, .2f);
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D eastCast = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.right), castLength);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.green, .75f);

        if(eastCast)
        {
            if(eastCast.collider.tag.Equals("Enemy"))
            {
                if(attackFlag)
                {
                    eastCast.collider.GetComponent<EnemyScript>().takeDamage(attackDamage);
                    attackFlag = false;
                }
            }
            else if(eastCast.collider.tag.Equals("Layer Spawner"))
            {
                GameObject.Destroy(gameObject);
            }
        }
        else
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);
        }
    }

    void canAttack()
    {
        attackFlag = true;
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
}
