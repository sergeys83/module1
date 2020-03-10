using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    Character character;
    BulletLauncher bL;
    private EffectMover eMover;

    public Damageble enemy;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<Character>();
        bL = GetComponentInChildren<BulletLauncher>();
      
    }

    public void AttackEnd()
    {
        character.SetState(Character.State.RunningFromEnemy);
       
    }

    public void onShoot()
    {
        bL.vfxCreator();
        bL.GunRotator(character.transform, character.targetCharacter.transform);
       
    }
    
    public void ShootEnd()
    {
        character.SetState(Character.State.Idle);
        bL.transform.rotation =  bL.GetOrigRotation();
    }

    public void FistAttackEnd()
    {
        character.SetState(Character.State.RunningFromEnemy);
      
    }
    
    //Только для "целевых" нанесений урона
    public void onEnemyDamaged()
    {
        
        character.GetDamage();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
