using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public ParticleSystem Effect;

    public void PlayEffect(Transform target =null)
    
    {
        if (target!=null)
        {
            Effect.transform.LookAt(target); 
        }
        
        Effect.Play();
    }
}
