using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GUISkin skin;
    private int level;
    private void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(10,10,1000,75), "Maze Runner");
        if (PlayerPrefs.GetInt("Level Completed") > 0)
        {
            if (GUI.Button(new Rect(450, 150, 100, 45), "Continue"))
            {
                level = PlayerPrefs.GetInt("Level Completed");
                PlayerPrefs.SetInt("Level Completed", level);
                SceneManager.LoadScene(level);
            }
        }
        if (GUI.Button(new Rect(450, 205, 100, 45), "Play"))
        {
            level = 1;
            PlayerPrefs.SetInt("Level Completed", level);
            SceneManager.LoadScene(level);
        }
        if (GUI.Button(new Rect(450, 255, 100, 45), "Quit"))
        {
            print("Quit Application");
            Application.Quit();
        }

    }

}
