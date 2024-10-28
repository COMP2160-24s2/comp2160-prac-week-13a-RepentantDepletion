using UnityEngine;
using UnityEngine.AI;

public class DroneFollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    [SerializeField] private float stoppingDistance = 1.5f; // Set stopping distance to avoid hitting player

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Find the player in the scene (assumes the player has the "Player" tag)
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Set the stopping distance to the NavMeshAgent
        agent.stoppingDistance = stoppingDistance;
    }

    void Update()
    {
        // Continuously update the destination to the player's position
        agent.SetDestination(player.position);
    }
}