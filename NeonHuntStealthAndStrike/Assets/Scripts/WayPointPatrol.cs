using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public List<Transform> waypoints;

    int m_CurrentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    { 
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (waypoints.Count == 0)
        {
            return;
        }

        float distanceToWaypoint = Vector3.Distance(waypoints[m_CurrentWaypointIndex].position, transform.position);

        if (distanceToWaypoint <=3)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Count;
        }
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);

    }
}
