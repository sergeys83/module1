using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundEventListener : MonoBehaviour
{
    public AudioClip clip;

    private MessageAttacked message;

   
    // Start is called before the first frame update
    void Awake()
    {
        EventManager.Instance.Sub(EventId.UnitDamage, ()=>OnUnitDamaged(EventManager.Instance.msg as MessageAttacked));
      // EventManager.Instance.Sub(EventId.UnitDamage, ()=>OnUnitDead(EventManager.Instance.msg as MessageDeath));
    }

   public void OnUnitDamaged(MessageAttacked msg)
   {
         message = msg;
        clip = message.Clip;
        SoundManager.Instance.Play(clip,message.Character.position);
    }

    public void OnDisable()
    {
        EventManager.Instance.UnSub(EventId.UnitDamage, ()=>OnUnitDamaged(message));
    }
   /* public void OnDestroy()
    {
        EventManager.Instance.UnSub(EventId.UnitDamage, OnUnitDamaged);
    }*/
}
