using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrel;
    [SerializeField] Transform pivot;
    // Start is called before the first frame update
    void Awake()
    {
        Spawn();
        InvokeRepeating(nameof(Spawn), 1.5f, 1.5f);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(bullet, barrel.position, pivot.rotation);
    }
}