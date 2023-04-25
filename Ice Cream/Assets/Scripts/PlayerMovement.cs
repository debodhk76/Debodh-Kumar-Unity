using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rigidplayer;
    public BoxCollider2D playercollider;
    public LayerMask GroundJump;
    public Animator anim;
    public float jump;
    public float speed;
    public AudioSource playerjump;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidplayer.velocity = Vector2.up * jump;
            playerjump.Play();
            

        }
        
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);

            transform.eulerAngles = new Vector3(0, 0, 0);

            anim.SetBool("Running", true);
            anim.SetBool("Jumping", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Falling", false);
        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);

            transform.eulerAngles = new Vector3(0, 180, 0);

            anim.SetBool("Running", true);
            anim.SetBool("Jumping", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Falling", false);

        }

        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Running", false);
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);
        }

        if(rigidplayer.velocity.y > 0f)
        {
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
            anim.SetBool("Running", false);
            anim.SetBool("Idle", false);

        }

        else if(rigidplayer.velocity.y < 0f)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
            anim.SetBool("Running", false);
            anim.SetBool("Idle", false);
        }

        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Jumping", false);
            anim.SetBool("Running", false);
            anim.SetBool("Falling", false);

            if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Jumping", false);
                anim.SetBool("Running", true);
                anim.SetBool("Falling", false);
            }

            else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Jumping", false);
                anim.SetBool("Running", true);
                anim.SetBool("Falling", false);
            }
        }

    }

    public bool IsGrounded()
    {
        return (Physics2D.BoxCast(playercollider.bounds.center, playercollider.bounds.size, 0f, Vector2.down, 0.1f, GroundJump));
    }
}
