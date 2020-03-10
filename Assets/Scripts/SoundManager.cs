using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
   
    public AudioSource[] audioSource;
    
    protected override void Awake()
    { 
      //  SM = this;
        
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play(AudioClip clip, Vector3 position)
    {
        AudioSource freeAudiosource = FindFreeaudioSource();
        freeAudiosource.transform.position = position;
        freeAudiosource.clip = clip;
        freeAudiosource.Play();
    }

  public AudioSource FindFreeaudioSource()
    {
        foreach (AudioSource item in audioSource)
        {
            if (!item.isPlaying)
            {
                return item;
            }       
        }
        return null;
    }
}
