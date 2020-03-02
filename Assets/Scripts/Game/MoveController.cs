using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
  public  Character curCharacter;
  public CharacterController cc;
  public Animator charAnim;
  
  public float speed;
  public float gravity;
  private Vector3 curPos, curVector;
  public GamePad MbController;
  
    // Start is called before the first frame update
    void Update()
    {
       Move();
      SetGravity();
    }

    private void Start()
    {
        MbController = GameObject.FindWithTag("MbController").GetComponentInChildren<GamePad>();
        cc = GetComponent<CharacterController>();
        charAnim = GetComponentInChildren<Animator>();
        curCharacter = GetComponent<Character>();
    }

    private void Move()
    {
        if (curCharacter.isDead())
        {
            return;
        }
        if (cc.isGrounded)
        {
            curVector = Vector3.zero;
            curVector.x = MbController.Horizontal() * speed;
            curVector.z = MbController.Vertical() * speed;

            if (curVector.x !=0||curVector.z !=0) 
            {
                charAnim.SetFloat("speed",speed);
            }
            else
            {
                charAnim.SetFloat("speed",0);
            }

// 
             if (Vector3.Angle(Vector3.forward, curVector)>1f||Vector3.Angle(Vector3.forward, curVector)==0f)
               {
                   Vector3 direction = Vector3.RotateTowards(transform.forward, curVector, speed, 0f);
                   transform.rotation = Quaternion.LookRotation(direction);
                   curCharacter.originalRotation = transform.rotation;
               }
        }
        
        curVector.y = gravity;
        cc.Move(curVector * Time.deltaTime);

    }

    private void SetGravity()
    {
        if (!cc.isGrounded)
        {
            gravity -=10f * Time.deltaTime;
        }
        else
        {
            gravity = -1f;
        }
       
    }
    private void Awake()
    {
        curCharacter.GetComponent<Character>();
        curPos = transform.position;
    }
    
}
