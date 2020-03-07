using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public static SoundManager SM;
   
    
    protected override void Awake()
    { 
        SM = this;
        
        DontDestroyOnLoad(SM.gameObject);
    }
    // called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
