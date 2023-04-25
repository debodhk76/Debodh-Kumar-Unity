using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject[] colliders;
    public int index = 0;
    public float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(colliders[index].transform.position, transform.position) < 0.1f)
        {
            index++;

            if(index >= colliders.Length)
            {
                index = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, colliders[index].transform.position, speed * Time.deltaTime);

    }

}
