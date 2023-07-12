using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float maxSpeed = Mathf.Infinity;
    Vector3 startingPos;
    public float currentSpeed { get; set; }
    public new Rigidbody rigidbody { get; private set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        startingPos = transform.position;
    }
    private void Start()
    {
        AddStartingForce();
    }

    public void ResetPosition()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.position = startingPos;
    }

    public void AddStartingForce()
    {
        float x;
        float y;
        if (Random.value<0.5f)
        {
             x = -1f;
        }
        else
        {
             x = 1f;
        }

        if (Random.value<0.5f)
        {
             y = Random.Range(-1f, -0.5f);
        }
        else
        {
             y = Random.Range(0.5f, 1f);
        }

        Vector3 direction = new Vector3(x, y,0f).normalized;
        rigidbody.AddForce(direction * baseSpeed, ForceMode.Impulse);
        currentSpeed = baseSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 direction = rigidbody.velocity.normalized;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        rigidbody.velocity = direction * currentSpeed;
        if (rigidbody.velocity.x < 0.5&& rigidbody.velocity.x >0)
        {
           rigidbody.AddForce(Vector3.right * currentSpeed, ForceMode.VelocityChange);
        }
        if (rigidbody.velocity.x > -0.5 && rigidbody.velocity.x < 0)
        {
            rigidbody.AddForce(Vector3.left * currentSpeed, ForceMode.VelocityChange);
        }
    }
        

}