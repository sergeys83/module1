using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMover : MonoBehaviour
{
    public float speed = 0f;
    public Transform target;
    public Action onShootend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool MoveToTarget(Vector3 targetPosition = default)
    {
        
        Vector3 distance = targetPosition - transform.position;
        Vector3 direction = distance.normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        
        Vector3 vector = direction * speed * Time.deltaTime;

        if (vector.magnitude < distance.magnitude)
        {
            transform.position += vector;
            return false;
        }
        transform.position = targetPosition;
    
        return true;

    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null)
        {
            if (MoveToTarget(target.position))
            {
                this.gameObject.SetActive(false);
              
               // Destroy(gameObject);
            }
        }
        
    }

}
