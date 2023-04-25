using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollission : MonoBehaviour
{
    public PlayerMovement movement;
    public GameController gameController;
    public BoxCollider obstacle;
    public LevelComplete anotherlevel;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            movement.enabled= false;
            gameController.GameOver();
            obstacle.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Trespassing Collider")
        {
            movement.enabled = false;
            anotherlevel.newlevel();
        }
    }


}
