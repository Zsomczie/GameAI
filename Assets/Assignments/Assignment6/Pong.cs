using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pong : MonoBehaviour
{
    public float speed = 8f;
    public new Rigidbody rigidbody { get; private set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void ResetPosition()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.position = new Vector3(rigidbody.position.x, 5f,0f);
    }

}