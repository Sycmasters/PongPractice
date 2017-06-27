using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{
    public MotionAxis movement;

    private Vector3 move;
    private Rigidbody2D rbody;

	// Use this for initialization
	void Start ()
    {
		if(rbody == null) { rbody = GetComponent<Rigidbody2D>(); }
	}
	
	// Update is called once per frame
	void Update ()
    {
        move = movement.GetMovement();
    }

    void FixedUpdate()
    {
        rbody.velocity = move;
    }
}
