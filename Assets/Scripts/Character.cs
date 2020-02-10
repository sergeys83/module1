using System.Collections;
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
    Quaternion originalRotation, enemyLook;

    public Animator animator;
    public Transform target;
    public Damageble enemyAimed;
   
    
    // Start is called before the first frame update
    void Start()
    {
       
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        animator = GetComponentInChildren<Animator>();
    }
    
    [ContextMenu("Attack")]
    public void AttackEnemy()
    {
        enemyAimed = target.gameObject.GetComponent<Damageble>();

        if (enemyAimed.isDead||target==null|| state == State.Dead)
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
                
                if ( RunTowards(target.position, distanceFromEnemy))
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
                
                transform.rotation = originalRotation= Quaternion.LookRotation(target.position);
                animator.SetTrigger("shoot");
                state = State.Shoot;

                break;
        }
    }
     // enemyLook  - запоминаем поворот в сторону атакуемого противника
    bool RunTowards(Vector3 targetPosition, float distanceFromTarget)
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
