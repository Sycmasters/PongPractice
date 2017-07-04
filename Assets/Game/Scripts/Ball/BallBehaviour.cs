using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public MotionAxis motion;
    public Rigidbody2D rbody;

    private Vector3 originPosition;

	// Use this for initialization
	void Start ()
    {
        if (!rbody) { rbody = GetComponent<Rigidbody2D>(); }
        originPosition = transform.position;

        RestartBall();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rbody.velocity = motion.GetMovement();
	}

    void RestartBall ()
    {
        // Move ball to original position
        transform.position = originPosition;

        // Start with a random direction
        Vector2 newDirection = Vector2.zero;
        newDirection.x = (Random.Range(0, 2) > 0) ? 1 : -1;
        newDirection.y = (Random.Range(0, 2) > 0) ? 1 : -1;

        // Apply 
        motion.movementForceOverride = newDirection;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Point")
        {
            // Give a point

            // Reset ball
            RestartBall();

            return; // We are done here, we don't need to go through the rest of the function
        }
        else if (collision.gameObject.tag == "Player")
        {
            // Go the other way on X axis
            motion.movementForceOverride = new Vector3(motion.movementForceOverride.x * -1, motion.movementForceOverride.y, motion.movementForceOverride.z);
        }
        else
        {
            // Go the other way on Y axis
            motion.movementForceOverride = new Vector3(motion.movementForceOverride.x, motion.movementForceOverride.y * -1, motion.movementForceOverride.z);
        }
    }
}
