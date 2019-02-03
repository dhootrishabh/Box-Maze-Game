using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField]
    private int loadLevelTo;

    private string loadPrompt;
    private bool inRange = false;
    private bool canLoadLevel = false;
    private int completedLevel;


    private void Start()
    {
        completedLevel = PlayerPrefs.GetInt("Level Completed");
        if(completedLevel == 0)
        {
            completedLevel = 1;
        }
        
        //print(canLoadLevel);
    }

    private void Update()
    {
        //print(canLoadLevel);
        if (canLoadLevel && Input.GetButtonDown("Action"))
        {
            SceneManager.LoadScene("Level" + loadLevelTo.ToString());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        canLoadLevel = false;
    }

    private void OnTriggerStay(Collider other)
    {
        inRange = true;
        if (loadLevelTo <= completedLevel)
        {
            canLoadLevel = true;
        }
        if (canLoadLevel)
        {
            loadPrompt = "Press [E] to load level" + loadLevelTo.ToString();
        }
        else
        {
            loadPrompt = "Level" + loadLevelTo.ToString() + " is locked.";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        canLoadLevel = false;
        loadPrompt = "";
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(30,Screen.height * .9f,200,40), loadPrompt);
    }

    

}
