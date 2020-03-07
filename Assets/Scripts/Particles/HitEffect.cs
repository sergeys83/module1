using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public ParticleSystem Effect;
    public float runSpeed;
    public bool isShooting = false;
    public bool PlayEffect(Transform target =null)
    
    {
        if (target!=null)
        {
            Effect.transform.LookAt(target); 
        }
        
        Effect.Play();
        isShooting = true;
        if (!MoveToTarget(target.position))
        {
           return false;
        }
        Effect.Stop();

        return true;
    }

    public bool MoveToTarget(Vector3 targetPosition=default)
    {
        Vector3 distance =  targetPosition- transform.position;
        Vector3 direction = distance.normalized;
        transform.rotation = Quaternion.LookRotation(direction);

       Vector3 vector = direction * runSpeed*Time.deltaTime;

        if (vector.magnitude<distance.magnitude)
        {
            transform.position += vector;
            return false;
        }
        transform.position = targetPosition;
        return true;
    
    }

    private void Update()
    {
        if (runSpeed!=0)
        {
            MoveToTarget();
            //transform.position += transform.forward * runSpeed * Time.deltaTime;
        }
    }
}
