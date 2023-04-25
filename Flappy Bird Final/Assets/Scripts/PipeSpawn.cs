using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{

    public GameObject pipe;
    public float heightoffset;
    public float spawnrate = 2f;
    public float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pipe, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnrate)
        {
            timer = timer + Time.deltaTime;
        }

        else
        {
            randomspawning();
            timer = 0;
        }
    }

    public void randomspawning()
    {
        float min = transform.position.y - heightoffset;
        float max = transform.position.y + heightoffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(min, max), 0), transform.rotation);

    }
}
