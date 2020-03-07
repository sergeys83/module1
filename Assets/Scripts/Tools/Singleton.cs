using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> :MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance==null)
                {
                    Debug.LogError($"_instance of type({typeof(T)}) do not exist");
                }
            }

            return _instance;
        }
    }
    // Start is called before the first frame update

    protected virtual void Awake()
    {
        T thisinstace = gameObject.GetComponent<T>();

        if (_instance!=null&&_instance!=thisinstace)
        {
            Destroy(gameObject);
            return;
        }

        _instance = thisinstace;

    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
