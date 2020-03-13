using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Character _character;
    private Health health;

    public int _helth;
    public int damage;
    public int deff;
    
    public CharacterSo data;
    // Start is called before the first frame update
    void Start()
    {
       // _character = GetComponent<Character>();
        health = GetComponent<Health>();
        SetData();
    }

    public void SetData()
    {
        health.current = data.health;
        damage = data.strenth;
        deff = data.deff;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
