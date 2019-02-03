using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int currentScore;
    public int highScore;

    public int tokenCount;
    private int totalTokenCount;
    public GameObject tokenParent;

    public int currentLevel = 0;
    public int unlockedLevel;

    public float startTime;
    private string currentTime;

    public GUISkin skin;
    public GUISkin alertSkin;
    public Rect timerRect;
    public Color warningColorTimer;
    public Color defaultColorTimer;

    public float winScreenWidth;
    public float winScreenHeight;
    private bool showWinScreen = false;

    private bool completed = false;

	// Use this for initialization
	void Start () {
        totalTokenCount = tokenParent.transform.childCount;

        if(PlayerPrefs.GetInt("Level Completed") > 0)
        {
            currentLevel = PlayerPrefs.GetInt("Level Completed");
        }
        else
        {
            currentLevel = 1;
        }
        print(currentLevel);
        //DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(!completed)
        {
            startTime = startTime - Time.deltaTime;
            currentTime = string.Format("{0:0.0}", startTime);
            if (startTime <= 0)
            {
                startTime = 0;
                SceneManager.LoadScene("Menu");
            }
        }
        
    }

    public void AddToken()
    {
        tokenCount += 1;
    }

    public void LoadNextLevel()
    {
        
        if(currentLevel < 2)
        {
            Time.timeScale = 1f;
            currentLevel = (currentLevel + 1);
            print(currentLevel);
            SaveGame();
            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            PlayerPrefs.SetInt("Level Completed", 0);
            print("You Win");
            
        }
        
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("Level Completed", currentLevel);
        PlayerPrefs.SetInt("Level " + currentLevel.ToString() + " Score", currentScore);
    }

    public void CompleteLevel()
    {
        showWinScreen = true;
        completed = true;
    }

    private void OnGUI()
    {
        if(startTime < 5f)
        {
            GUI.skin = alertSkin;
        }
        else
        {
            GUI.skin = skin;
        }
        GUI.Label(timerRect, currentTime);
        GUI.skin = skin;
        GUI.Label(new Rect(25, 75, 200, 200), tokenCount.ToString() + "/" + totalTokenCount.ToString());

        if(showWinScreen)
        {
            Rect WinScreenRect = new Rect(Screen.width / 2 - (Screen.width * .5f/2), Screen.height / 2 - (Screen.height * .5f/2), Screen.width * .5f, Screen.height * .5f);
            GUI.Box(WinScreenRect, "Yeah");

            int gameTime = (int)startTime;
            currentScore = tokenCount * gameTime;

            if(GUI.Button(new Rect(WinScreenRect.x + WinScreenRect.width - 170, WinScreenRect.y + WinScreenRect.height - 60, 150, 40), "Continue"))
            {
                LoadNextLevel();
            }
            if (GUI.Button(new Rect(WinScreenRect.x + 20, WinScreenRect.y + WinScreenRect.height - 60, 100, 40), "Quit"))
            {
                SceneManager.LoadScene("Menu");
                Time.timeScale = 1f;
            }
            GUI.Label(new Rect(WinScreenRect.x + 20, WinScreenRect.y + 60, 300, 50), "Level " + (currentLevel).ToString() + " Completed");
            GUI.Label(new Rect(WinScreenRect.x + 20, WinScreenRect.y + 120, 300, 50), "Score: " + currentScore.ToString());
            
        }
    }
}
