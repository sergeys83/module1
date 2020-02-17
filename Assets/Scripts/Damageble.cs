using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Damageble : MonoBehaviour
{
    
   public int health;
   public Character character;
   public Animator animator;
   public bool isDead = false;
    private Health _health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetDamage()
    {
        character = GetComponent<Character>();
        animator = GetComponentInChildren<Animator>();
        _health = GetComponent<Health>();

        _health.ApplyDamage(2f);
        
        if (_health.current<=0)
        {
            Debug.Log($"{character.gameObject.name} is killed");
           isDead = true;
            character.SetState(Character.State.Dead);
            animator.SetBool("health", true);
        }
         
    }
       // временно для установки юнитов в исходное положение
    [ContextMenu("Ressurect All")]
    /* public void Ressurect()
     {

         List<Damageble> deadmen = new List<Damageble>();   
         deadmen = FindObjectsOfType<Damageble>().ToList();
         foreach (var item in deadmen)
         {
             if (item.isDead)
             {
                 item.isDead = false;
                 item.GetComponent<Character>().SetState(Character.State.Idle);
                 item.animator.SetBool("health", item.isDead);
                 item.animator.SetTrigger("ressurect");

                 item.health += 1;
             }
           } 

        }*/

// Update is called once per frame
void Update()
    {
        
    }
}
