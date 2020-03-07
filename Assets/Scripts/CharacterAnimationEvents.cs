using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    Character character;

    public Damageble enemy;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<Character>();
        
    }

    public void AttackEnd()
    {
        character.SetState(Character.State.RunningFromEnemy);
       
    }

    public void onShoot()
    {
        
    }
    
    public void ShootEnd()
    {
        character.SetState(Character.State.Idle);
      
    }

    public void FistAttackEnd()
    {
        character.SetState(Character.State.RunningFromEnemy);
      
    }
    
    //Только для "целевых" нанесений урона
    public void onEnemyDamaged()
    {
        enemy = character.enemyAimed;
        enemy.GetDamage();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
