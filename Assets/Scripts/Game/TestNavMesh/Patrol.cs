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
    
    private NavMeshAgent agent;
    public Transform T1; //временно, для определения второй точки маршрута
   
    private int destPoint = 0;
    public List<Vector3> wayPoints;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        
        startPos = transform.position;
        endPos =T1.position;
        
        wayPoints.Add(startPos);
        wayPoints.Add(endPos);
        agent.autoBraking = false;
        
        GotoNextPoint();

    }
    void GotoNextPoint() {
        // Returns if no points have been set up
        if (wayPoints.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = wayPoints[destPoint];

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % wayPoints.Count;
    }

    // Update is called once per frame
    void Update()
    {
        curPos = agent.transform.position;
        if (!agent.pathPending && agent.remainingDistance < .2f)
        {
            GotoNextPoint();
        }
       
    }
}
