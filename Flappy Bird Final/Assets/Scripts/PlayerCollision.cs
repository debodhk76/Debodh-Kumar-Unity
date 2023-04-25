using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Rigidbody2D rigidbird;
    public GameOver gameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Non-Collider")
        {
            playerMovement.enabled= false;
            rigidbird.freezeRotation= false;
            gameOver.gameover();
        }
    }
}
