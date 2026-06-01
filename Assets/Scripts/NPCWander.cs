using UnityEngine;
using UnityEngine.AI;

public class NPCWander : MonoBehaviour
{
    NavMeshAgent agent;

    public float wanderRadius = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        InvokeRepeating("MoveToNewPosition", 0f, 5f);
    }

    void MoveToNewPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;

        randomDirection += transform.position;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1))
        {
            agent.SetDestination(hit.position);
        }
    }
}