using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]GameObject bridge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = new Vector3(-4.32f, 0.58f,-1.06f);
        collision.transform.rotation = Quaternion.Euler(Vector3.zero);
        bridge.SetActive(true);
    }
}
