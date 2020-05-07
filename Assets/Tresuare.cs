using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tresuare : MonoBehaviour
{
    public bool isGrounded = false;
    public float time = 15f;
    public BoxCollider obj;

    private TresureSpawner ts;
    // Start is called before the first frame update
    void Start()
    { 
        obj = GetComponent<BoxCollider>();
        obj.isTrigger = false;
        ts = GetComponentInParent<TresureSpawner>();
      //  StartCoroutine( DownCounter(time=3f));
    }

    public IEnumerator DownCounter(float time)
    {
        while (time>0)
        {
            time--;
            yield return new WaitForSeconds(time); 
        }
       Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<BoxCollider>()!=null)
        {
            isGrounded = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            obj.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            obj.isTrigger = false;
            StopAllCoroutines();
            ts.prefubs.Remove(this);
            Destroy(obj);
            Debug.Log("Player is coming");
            StartCoroutine(DownCounter(3f));
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
