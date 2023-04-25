using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{

    public float moveleft;
    public float vanishpoint = -15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - new Vector3(moveleft * Time.deltaTime, 0, 0);

        if(transform.position.x < vanishpoint)
        {
            Destroy(gameObject);
        }
    }
}
