using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField] float fieldOfView = 360;
    [SerializeField] float viewDistance = 15;
    [SerializeField] public Transform target;
    [SerializeField] Transform rayOrigin;
    [SerializeField]List<GameObject> targets = new List<GameObject>();
    
    public bool _playerVisible = false;
    public bool playerVisible => _playerVisible;
    private void Start()
    {
    }
    void FixedUpdate()
    {
        targets = GameObject.FindGameObjectsWithTag("Cutter").ToList();

        Vector3 min = Vector3.positiveInfinity;
        foreach (var enemy in targets)
        {
            Vector3 current= enemy.transform.position - rayOrigin.transform.position;
            if (min.magnitude>current.magnitude)
            {
                min = current;
                target = enemy.transform;
            }
        }
        if (target!=null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            Vector3 angleFrom = target.position - transform.position;
            float angle = Vector3.Angle(angleFrom, transform.forward);
            //Debug.Log(angle);
            RaycastHit hitInfo;
            if (distance < viewDistance && angle < fieldOfView / 2)
            {
                Debug.DrawLine(rayOrigin.position, transform.position + angleFrom);
                //rayOrigin.rotation = Quaternion.Euler(target.position + angleFrom);
                rayOrigin.LookAt(target.position);
                if (Physics.Raycast(rayOrigin.position, target.position - rayOrigin.position, out hitInfo, viewDistance))
                {
                    Debug.Log("target in range");
                    if (hitInfo.collider.gameObject.layer == 6)
                    {
                        _playerVisible = true;
                        Debug.Log("Found player");
                    }
                }
                else
                {
                    target = GameObject.FindGameObjectWithTag("Cutter").transform;
                }
            }
            else
            {
                _playerVisible = false;
            }
        }
        
    }
}
