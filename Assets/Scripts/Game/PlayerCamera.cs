﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Vector3 curPosition;
    [Range(1,10)]
    public float speed;
    private Quaternion curRotation;
    public Transform player;
    public Vector3 curPlayerPos;
    private Vector3 _delta;
    public Vector3 Delta 
    {
        get { return _delta ;}
        set { _delta = transform.position - player.position; }
    }
    

    public LayerMask lMask;
    
    // Start is called before the first frame update
    void Start()
    {
        curPosition = transform.position;
        curRotation = transform.rotation;
        Delta = transform.position - player.transform.position;
        curPlayerPos = player.transform.position;
    }

    private void LateUpdate()
    {
       //transform.position = curPosition; // поворот камеры игрока.

        Vector3 newCampos = player.transform.position+ Delta;
        transform.position = Vector3.Slerp(transform.position, newCampos, speed*Time.deltaTime);
        curPosition = transform.position;
         Quaternion curRotation = Quaternion.LookRotation(player.position- transform.position); 
        transform.rotation = Quaternion.Slerp(transform.rotation, curRotation, speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(player.position, transform.position - player.transform.position, out hit,Vector3.Distance(transform.position,player.position),lMask))
        {
            transform.position = hit.point;
            transform.LookAt(player.position);
        }
    }

    // Update is called once per frame
   /* void LateUpdate()
    {

      //  transform.LookAt(player);
    }*/

    private void Moves()
    {
        
    }
}
