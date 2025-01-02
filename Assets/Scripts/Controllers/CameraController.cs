using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject _target;
    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100.0f))
            {
                _target = hit.collider.gameObject;
            }
        }
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (_target == null) 
            return;

        Vector3 dist = _target.transform.position - transform.position;
        Debug.Log(dist.magnitude);
        if (dist.magnitude > 10.0f)
        {
            transform.position = Vector3.Slerp(transform.position, dist, 1.0f);
            transform.LookAt(_target.transform);
        }
    }
}
