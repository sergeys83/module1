using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioClip clip;

    // Start is called before the first frame update
   
    public void Play()
    {
        MessageAttacked msg = new MessageAttacked(transform,clip);
        EventManager.Instance.SendEvent(EventId.UnitDamage, msg);
     
    }

}
