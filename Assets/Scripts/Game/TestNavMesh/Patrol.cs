using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 curPos;

    private Animator charAnimator;
    private NavMeshAgent agent;
    public Transform T1; //временно, для определения второй точки маршрута
   
    private int destPoint = 0;
    public List<Vector3> wayPoints;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        charAnimator = GetComponentInChildren<Animator>();
        
        startPos = transform.position;
        endPos =T1.position;
        
        wayPoints.Add(startPos);
        wayPoints.Add(endPos);
        agent.autoBraking = false;
        
        GotoNextPoint();

    }
    void GotoNextPoint() {
       
        if (wayPoints.Count == 0)
            return;

        agent.destination = wayPoints[destPoint];
        charAnimator.transform.LookAt(agent.destination);
        Debug.Log($"speed= {agent.speed}");

        destPoint = (destPoint + 1) % wayPoints.Count;
    }

    void Update()
    {
        curPos = agent.transform.position;
        if (!agent.pathPending && agent.remainingDistance < .2f)
        {
            GotoNextPoint();
        
        }
        if (agent.hasPath)
        {
            charAnimator.SetFloat("speed", 2f);
        }
       
    }
}
