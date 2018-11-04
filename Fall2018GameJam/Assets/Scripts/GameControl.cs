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
    public List<string> Scenes = new List<string>();
    private string currentLevel;


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

        if(GameObject.FindGameObjectsWithTag("Player").Length != 0)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        
        currentLevel = SceneManager.GetActiveScene().name;
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

    public void EndLevel()
    {
        //Finds the scene in the list to determine what the next level should be
        int j = Scenes.IndexOf(currentLevel);
        print(Scenes.Count);
        print(j);

        //If we are at the end of the list, loop to the beginning/menu
        if (j == Scenes.Count - 1)
        {
            currentLevel = Scenes[0];
            print("trigger");
        }
        else
        {
            /*
             * Otherwise, go to the next leve. As a note, if IndexOf fails, it will return -1
             * in which case I want it to go to scene 0 or the main menu, and since -1 + 1 = 0,
             * no additional code is required.
             */
            currentLevel = Scenes[j + 1];
        }

        //Loads the new currentLevel
        print(currentLevel);
        SceneManager.LoadScene(currentLevel);
    }




}