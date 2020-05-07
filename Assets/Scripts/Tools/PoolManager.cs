using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private static PoolManager _instance;

    
    public GameObject bulletPrefub;
    [SerializeField]
    private List<GameObject> _bulletPool = new List<GameObject>(10);

    [SerializeField] private GameObject _bulletContainer;
    protected override void Awake()
    { 
        DontDestroyOnLoad(this.gameObject);
    }

    
    private void Start()
    {
        _bulletPool = GenerateBullets(10);
    }

    public List<GameObject> GenerateBullets(int amountBullets)
    {
        for (int i = 0; i < amountBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefub,_bulletContainer.transform);
            _bulletPool.Add(bullet);
            
            bullet.SetActive(false);
        }
        
        return _bulletPool;
    }

    public GameObject RequestBullet(Transform owner)
    {
        foreach (var bullet in _bulletPool)
        {
            if (bullet.activeInHierarchy==false)
            {
                bullet.SetActive(true);
                bullet.transform.position = owner.position;
                return bullet;
            }
        }
        
        GameObject newBullet = Instantiate(bulletPrefub,_bulletContainer.transform);
        newBullet.transform.position = owner.position;
        _bulletPool.Add(newBullet);
        return newBullet;
    }

    
}
