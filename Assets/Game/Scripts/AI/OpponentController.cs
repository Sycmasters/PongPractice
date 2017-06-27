using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public MotionAxis motion;
    public Transform target;

    private Rigidbody2D rbody;
    private Vector3 move;

    // Use this for initialization
    void Start()
    {
        if (rbody == null) { rbody = GetComponent<Rigidbody2D>(); }
    }

    // Update is called once per frame
    void Update ()
    {
        move = Vector3.zero;

        // If the target is above, just make it positive to move AI up
        if ((target.position.y - transform.position.y) > 0.1f)
        {
            move.y = motion.forceBoost;
        }
        // If the target is below, just make it negative to move AI down
        else if ((target.position.y - transform.position.y) < -0.1f)
        {
            move.y = -motion.forceBoost;
        }
        // If is alike just stop the AI
        // This way we can set the AI difficulty through speed
        else
        {
            move.y = 0;
        }
        Debug.Log((target.position.y - transform.position.y));

        // Since AI is not controlled by input we overwrite the input movment
        motion.movementForceOverride = move;
    }

    void FixedUpdate ()
    {
        rbody.velocity = motion.GetMovement();
    }
}
