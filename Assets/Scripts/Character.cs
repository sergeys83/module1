using System.Collections;
using System.Collections.Generic;
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
    Quaternion OriginalRotation;

    public Animator animator;
    public Transform target;

    public Damageble enemyKilled;
   
    
    // Start is called before the first frame update
    void Start()
    {
       
        originalPosition = transform.position;
        OriginalRotation = transform.rotation;
        animator = GetComponentInChildren<Animator>();
    }

    [ContextMenu("Attack")]
    public void AttackEnemy()
    {
       enemyKilled = target.gameObject.GetComponent<Damageble>();

        if (enemyKilled.isDead||target==null|| this.state == State.Dead)
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
       
        {
            case State.Idle:
                transform.rotation = OriginalRotation;
                animator.SetFloat("speed", 0f);
                break;

            case State.RunningToEnemy:
                animator.SetFloat("speed", runSpeed);
                if ( RunTowards(target.position, distanceFromEnemy))
                    state = State.BeginAttack;
                break;

            case State.RunningFromEnemy:
                animator.SetFloat("speed", runSpeed);
                if (RunTowards(originalPosition, 0f))
                    state = State.Idle;
                break;

            case State.BeginAttack:
                animator.SetFloat("speed", 0f);
                animator.SetTrigger("attack");
                state = State.Attack;
                break;

            case State.Attack:
                animator.SetFloat("speed", 0f);

                enemyKilled.GetDamage();
                break;

            case State.BeginShoot:
                animator.SetFloat("speed", 0f);
                animator.SetTrigger("shoot");
                state = State.Shoot;

                enemyKilled.GetDamage();
                break;
        }
       
          
    }

    bool RunTowards(Vector3 targetPosition, float distanceFromTarget)
    {
        Vector3 distance =  targetPosition- transform.position;
        Vector3 direction = distance.normalized;
        transform.rotation = Quaternion.LookRotation(direction);

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
