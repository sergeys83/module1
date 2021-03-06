﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum State
    {
        Idle,
        RunningToEnemy,
        RunningFromEnemy,
        BeginAttack,
        Attack,
        Shoot,
        BeginShoot,
        Dead
    }

    public enum Weapon
    {
        Pistol,
        Bat,
        Fists
    }
    
    public State state = State.Idle;
    public Weapon weapon;

    public float runSpeed = 0f;
    public float distanceFromEnemy;
    Vector3 originalPosition;
   public Quaternion originalRotation, enemyLook;
   
    public Animator animator;
    public Character targetCharacter;
    public Damageble enemyAimed;
    private Health _health;
    
    public AudioClip deathClip;
    public AudioClip damageClip;
    private HitEffect _hitEffect;

    // Start is called before the first frame update
    void Start()
    {
       
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        animator = GetComponentInChildren<Animator>();
        _hitEffect = GetComponentInChildren<HitEffect>();
    }
    public bool isDead()
    {
        return state == State.Dead;
    }
    public bool isIdle()
    {
        return state == State.Idle;
    }
    [ContextMenu("Attack")]
   
    public void GetDamage()
    {
       
        _health = targetCharacter.GetComponent<Health>();

        HitSound hitSound = GetComponent<HitSound>();

        if (_health!=null)
        {
            _health.ApplyDamage(2f);
            hitSound.Play();
            SoundManager.Instance.Play(damageClip,targetCharacter.transform.position);
            
            if (_health.current <= 0)
            {
                Debug.Log($"{targetCharacter.gameObject.name} is killed");
                
                SoundManager.Instance.Play(deathClip,targetCharacter.transform.position);
                targetCharacter.SetState(State.Dead);
                targetCharacter.animator.SetBool("isDead", true);
            }

        }

    }
    public void AttackEnemy()
    {
        
        if (targetCharacter.isDead()|| targetCharacter == null|| isDead())
        {
            Debug.Log("Deadmen can't attack");
            return;
        }
       
        switch (weapon)
        {
            case Weapon.Pistol:
                state = State.BeginShoot;
               
                break;
            
            case Weapon.Bat:
            case Weapon.Fists:
                state = State.RunningToEnemy;
                break;
         
        }
       
    }
    public void SetState(State state)
    {
        this.state = state;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
       
        {  //поменять поворот 
            case State.Idle:
                
                transform.rotation = originalRotation;
                animator.SetFloat("speed", 0f);
                
                break;

            case State.RunningToEnemy:
               
                animator.SetFloat("speed", runSpeed);
                
                if ( RunTowards(targetCharacter.transform.position, distanceFromEnemy))
                    state = State.BeginAttack;
                    originalRotation = enemyLook;
                break;

            case State.RunningFromEnemy:
             
                animator.SetFloat("speed", runSpeed);
                if (RunTowards(originalPosition, 0f))
                    state = State.Idle;
                break;
            
            // проверяем что в руках дубинка или пусто. или лучше добавить новое ссостояние?
            case State.BeginAttack:
               
                animator.SetFloat("speed", 0f);
                animator.SetTrigger(weapon == Weapon.Bat ? "attack" : "fistAttack");
                state = State.Attack;
                
                break;

            case State.Attack:
            
                break;
            
                //поворот к цели при стрельбе
            case State.BeginShoot:
                transform.LookAt(targetCharacter.transform);
                animator.SetTrigger("shoot");
                state = State.Shoot;
            
                break;
            
            case State.Dead:
                
                break;
        }
    }
     // enemyLook  - запоминаем поворот в сторону атакуемого противника
   public bool RunTowards(Vector3 targetPosition, float distanceFromTarget)
    {
        Vector3 distance =  targetPosition- transform.position;
        Vector3 direction = distance.normalized;
        transform.rotation = enemyLook = Quaternion.LookRotation(direction);

        targetPosition -=  direction*distanceFromTarget;
        distance = targetPosition - transform.position;

        Vector3 vector = direction * runSpeed;

        if (vector.magnitude<distance.magnitude)
        {
            transform.position += vector;
            return false;
        }
        transform.position = targetPosition;
        return true;
    }

}
