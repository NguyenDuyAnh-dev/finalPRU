using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lenxuong : MonoBehaviour
{
        public float start, end;
    public float speed = 1f; // Adjust the speed of movement
    private bool movingRight = true; // Flag to determine the direction

    // Start is called before the first frame update
    void Start()
    {
		start = transform.position.y - 2f; 
		end = transform.position.y + 2f;
	}

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position based on the current position, speed, and time
        float newPosition = transform.position.y + (speed * (movingRight ? 1 : -1) * Time.deltaTime);

        // Check if the object has reached the end points
        if (newPosition >= end)
        {
            newPosition = end;
            movingRight = false;
        }
        else if (newPosition <= start)
        {
            newPosition = start;
            movingRight = true;
        }

        // Update the object's position
        transform.position = new Vector3( transform.position.x,newPosition, transform.position.z);
    }
}
