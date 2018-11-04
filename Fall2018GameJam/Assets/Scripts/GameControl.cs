/*
 * Code Originally written for 2018 Global Gamejam by Jonathan Quinn and his Teammates
 * Repurposed and Heavily modified on 6/28/18 for Project Zephyr
 * 
 * This code creates a game manager that stores data across scenes, and is used for
 * primarily for scene management. Tracks the level the user is on and advances them
 * to the next one upon recieving a signal from the Level Controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    private GameObject player;
    

    // Use this for initialization
    /*
     * Upon creation, determines if a gamecontroller already exists from a different
     * scene, and if so destroys itself. Otherwise it remains on and takes over
     * game control duties.
     */
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectsWithTag("Player")[0];
	}

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public GameObject getPlayer()
    {
        return player;
    }

 

    
}