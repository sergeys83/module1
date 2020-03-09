using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioClip clip;

    // Start is called before the first frame update
   
    public void Play()
    {
        SoundManager.Instance.Play(clip,transform.position);
       
    }

}
