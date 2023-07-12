using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Pong
{
    public Vector3 direction { get; private set; }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector3.down;
        }
        else
        {
            direction = Vector3.zero;
        }
        if (direction.sqrMagnitude != 0)
        {
            rigidbody.AddForce(direction * speed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.rigidbody!=null)
        {
            collision.rigidbody.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
        }
    }

}