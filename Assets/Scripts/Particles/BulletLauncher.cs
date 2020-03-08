using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    private GameObject vfxGo;
    public GameObject vfxPrefub;
    public Transform creator;
    private Quaternion origRotation;


    // Start is called before the first frame update
    void Start()
    {
        origRotation = transform.rotation;
    }

    public void vfxCreator()
    {
        vfxGo = Instantiate(vfxPrefub, creator.position, Quaternion.identity, creator);
        vfxGo.transform.localRotation = transform.rotation;
    }
    public void GunRotator(Transform owner, Transform target)
    {
        transform.localRotation = owner.rotation;
        vfxGo.GetComponent<EffectMover>().target = target;
    }

    public Quaternion GetOrigRotation()
    {
        return origRotation;
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
