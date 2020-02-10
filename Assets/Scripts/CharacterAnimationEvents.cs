using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    Character character;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<Character>();
    }

    public void AttackEnd()
    {
        character.SetState(Character.State.RunningFromEnemy);
    }

    public void ShootEnd()
    {
        character.SetState(Character.State.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
