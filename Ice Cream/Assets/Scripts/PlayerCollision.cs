using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public Animator anim;
    public AudioSource score;
    public AudioSource playerdeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collectables")
        {
            Destroy(collision.gameObject);
            score.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            playerMovement.enabled = false;
            anim.SetTrigger("Death");
            playerdeath.Play();
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Scene1");
    }

}
