using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class BgSounds
{
    public string scene;
    public AudioClip clip;
    
}
public class SoundManager : Singleton<SoundManager>
{
    public BgSounds[] BgSoundses;
    public AudioSource[] audioSource;
    public AudioSource backGround;
    protected override void Awake()
    { 
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        EventManager.Instance.Sub(EventId.Scenechanged, ()=>PlayBgSound(EventManager.Instance.msg as SceneChanged));
    }

    public void Play(AudioClip clip, Vector3 position)
    {
        AudioSource freeAudiosource = FindFreeaudioSource();
        freeAudiosource.transform.position = position;
        freeAudiosource.clip = clip;
        freeAudiosource.Play();
    }

    public void PlayBgSound(SceneChanged msg)
    {
        Debug.Log("sound " + msg.scene);
        foreach (BgSounds item in BgSoundses)
        {
            if (item.scene==msg.scene)
            {
                
                if (backGround.isPlaying)
                {
                    backGround.Stop();
                }
                backGround.clip = item.clip;
                backGround.Play();
            }
        }
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
