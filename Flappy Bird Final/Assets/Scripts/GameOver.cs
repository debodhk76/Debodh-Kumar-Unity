using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverpanel;
    public Text scoretext;
    public Score displayscore;


    // Start is called before the first frame update
    void Start()
    {
        gameoverpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerfinalscore()
    {
        scoretext.text = "Score: " + displayscore.ToString();
    }

    public void gameover()
    {
        gameoverpanel.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
