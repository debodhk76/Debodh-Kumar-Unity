using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int playerscore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectables")
        {
            playerscore = playerscore + 1;

            ScoreText.text = playerscore.ToString();
        }
    }
}
