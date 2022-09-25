
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public int currentLevel;
    public Button jupiter;
    public Button moon;
    int collectCount;
    public Button Continue;
    public static bool cont = false;
    Text collectedText;


    private void Start()
    {
        collectedText = GameObject.Find("CollectedText").GetComponent<Text>();
        collectCount = PlayerPrefs.GetInt("RocketCount");
        if (collectCount >= 10)
        {
            moon.interactable = true;
        }
        if (collectCount >= 20)
        {
            jupiter.interactable = true;
        }
        if(cont)
        {
            Continue.interactable = true;
        }
        if(!cont)
        {
            Continue.interactable = false;
        }
        collectedText.text = PlayerPrefs.GetInt("RocketCount").ToString();

    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene(8);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickMars()
    {
        SceneManager.LoadScene(2);
    }
    public void OnClickMoon()
    {
       
            SceneManager.LoadScene(3);
    }
    public void OnClickJupiter()
    {
        
            SceneManager.LoadScene(4);
        
    }
    public void OnClickRetry()
    {
        SceneManager.LoadScene(currentLevel);
    }
    public void OnClickSelectLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickContinue()
    {
        collectedText.text =  collectCount.ToString();
        SceneManager.LoadScene(1);
    }
    public void OnClickNewGame()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("RocketCount");
        collectedText.text = collectCount.ToString();
        SceneManager.LoadScene(1);
        cont = true;
    }
    public void OnClickPause()
    {
        Time.timeScale = 0;
        AudioScript.instance.ad[1].Stop();
    }
    public void OnClickResume()
    {
        Time.timeScale = 1;
        AudioScript.instance.ad[1].Play();
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene(9);
    }

}


