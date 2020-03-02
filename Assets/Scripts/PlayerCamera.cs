using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Vector3 curPosition;
    [Range(0,1)]
    public float speed;
    private Quaternion curRotation;
    public Transform player;
    public Vector3 curPlayerPos;
    public Vector3 delta;
    
    // Start is called before the first frame update
    void Start()
    {
        curPosition =transform.position;
        curRotation = transform.rotation;
        delta = transform.position - player.transform.position;
        curPlayerPos = player.transform.position;
    }

    private void Update()
    {
        curPosition.x +=Input.GetAxis("Mouse X");
        curPosition.z += Input.GetAxis("Mouse Y");
        transform.position = curPosition;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newCampos = player.transform.position + delta;
        transform.position = Vector3.Slerp(curPosition,newCampos,0.5f);
        curPosition = transform.position;
        transform.LookAt(player);
    }

    private void Moves()
    {
        
    }
}
