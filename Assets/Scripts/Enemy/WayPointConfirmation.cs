using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        Debug.Log("Is on NavMesh: " + agent.isOnNavMesh);
    }
}
