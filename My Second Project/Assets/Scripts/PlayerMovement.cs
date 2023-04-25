using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rigidplayer;
    public float sideForce = 10f;
    public float force = 1000f;
    public float speed = 10f;
    public GameController gamefinished;

    // Update is called once per frame
    void FixedUpdate()
    {
       
        rigidplayer.AddForce(0, 0, force * Time.deltaTime);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //rigidplayer.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            transform.position = transform.position + new Vector3(sideForce * Time.deltaTime, 0, 0);
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            //rigidplayer.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            transform.position = transform.position - new Vector3(sideForce * Time.deltaTime, 0, 0);
        }

        gamefinished.endgame();
    }

    



}
