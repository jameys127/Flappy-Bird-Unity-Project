using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightSpawnPoint = 10;
    private float speedCounter = 0;
    private bool birdIsAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else if(timer >= spawnRate && birdIsAlive == true)
        {
            spawnPipe();
            timer = timer - spawnRate;
        }
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightSpawnPoint;
        float heighestPoint = transform.position.y + heightSpawnPoint;
        GameObject instantiatedPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint,
                                                                    heighestPoint), 0), transform.rotation, this.transform);
        if (speedCounter >= 1)
        { 
            instantiatedPipe.GetComponent<PipeScript>().increaseSpeed(speedCounter);
        }
        
    }

    public void spawnAtIncreasedSpeedCheck()
    {
        speedCounter++;
    }

    public void birdIsDead()
    {
        birdIsAlive = false;
    }
    
}
