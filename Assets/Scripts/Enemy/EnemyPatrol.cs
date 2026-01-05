using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public float patrolRadius = 8f;
    public float detectionRange = 15f;
    public float waitTime = 2f;

    private NavMeshAgent agent;
    private Transform player;
    private Vector3 origin;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        origin = transform.position;

        SetNewDestination();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            agent.isStopped = true;

            Vector3 lookPos = player.position - transform.position;
            lookPos.y = 0;
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
        else
        {
            agent.isStopped = false;
            timer += Time.deltaTime;

            if (!agent.pathPending && agent.remainingDistance < 0.5f && timer >= waitTime)
            {
                SetNewDestination();
                timer = 0f;
            }
        }
    }

    void SetNewDestination()
    {
        Vector3 randomDir = Random.insideUnitSphere * patrolRadius;
        randomDir += origin;

        if (NavMesh.SamplePosition(randomDir, out NavMeshHit hit, patrolRadius, NavMesh.AllAreas))
        {
            agent.destination = hit.position;
        }
    }
}
