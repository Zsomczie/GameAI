using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movable : MonoBehaviour
{
    [SerializeField] Transform target;
    Rigidbody rgb;
    public float pushForce = 1;
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();

        //rgb.AddForceAtPosition(Vector3.one * 1, transform.position, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Agent"))
        {
            transform.Translate(Vector3.one* Time.deltaTime);
        }
    }

}
