using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int playerscore;
    public Text scoretext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collider")
        {
            finalscore();
            scoretext.text = playerscore.ToString();  
        }
    }

    public void finalscore()
    {
        playerscore = playerscore + 1;
    }
}
