using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    Rigidbody2D playerRigidBody;
    public float speed;
    
    void Start () {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + movement * speed * Time.deltaTime;
    }

}
