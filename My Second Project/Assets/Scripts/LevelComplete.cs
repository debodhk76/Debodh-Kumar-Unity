using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject nextlevel;
    public GameObject scorevanish;

    private void Start()
    {
        nextlevel.SetActive(false);
    }

    public void newlevel()
    {

        nextlevel.SetActive(true);
        scorevanish.SetActive(false);
    }
}
