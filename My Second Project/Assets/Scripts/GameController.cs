using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameController;
    public GameObject scorevanish;
    public Transform playerposition;
    public Text scoretext;

   
    private void Start()
    {
        
        gameController.SetActive(false);
    }

    public void GameOver()
    {
        gameController.SetActive(true);
        scoretext.text = "Score: " + playerposition.position.z.ToString("0");
        scorevanish.SetActive(false);
    }

    public void endgame()
    {
        if (playerposition.position.y <= -1f)
        {
            gameController.SetActive(true);

            if(playerposition.position.y >= -1.1111f) 
            {
                scorevanish.SetActive(false);
                scoretext.text = "Score: " + playerposition.position.z.ToString("0");

            }

        }
    }

    public void restart()
    {
        SceneManager.LoadScene("CubeRunner");
    }

    public void OnApplicationQuit()
    {
        Application.Quit(); 
    }

}
