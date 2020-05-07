using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureSpawner : MonoBehaviour
{
    public GameObject spawner;
    public Tresuare TresuarePrefab;
    public List<string> dropList;
    public List<Tresuare> prefubs = new List<Tresuare>();

    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = spawner.transform.position;
       
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
      //  var pos = new Vector3(Random.Range(-13, 0), 0, Random.Range(-5, 7));
        if (prefubs.Count<1)
        {
          var tr =   Instantiate(TresuarePrefab,pos,Quaternion.Euler(new Vector3(-90,0,0)),spawner.transform);
          prefubs.Add(tr);
        }
    }
}
