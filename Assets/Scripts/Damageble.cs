using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageble : MonoBehaviour
{
    
   public int health;
   public Character character;
   public Animator animator;
   public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        animator = GetComponentInChildren<Animator>();
    }

    public void GetDamage()
    {
            isDead = true;
        Debug.Log($"{character.gameObject.name} is killed");
        animator.SetInteger("health", 0);
            character.state = Character.State.Dead;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
