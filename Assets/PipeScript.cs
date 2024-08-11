using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private float deadzone = -40; 
    private float moveSpeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }

    public void increaseSpeed(float interval)
    {
        moveSpeed += interval;
        // Debug.Log("increasing speed" + moveSpeed);

    }

    public void stopSpeed()
    {
        moveSpeed = moveSpeed - moveSpeed;
        Debug.Log("Moving has Stopped");
    }

    
}
