using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshGizmo : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        // Get the NavMeshAgent component attached to the player
        agent = GetComponent<NavMeshAgent>();
    }

    // This method will draw the NavMesh path in the Scene view as Gizmos
    void OnDrawGizmos()
    {
        // Ensure there's a NavMeshAgent on this object and it has a valid path
        if (agent != null && agent.path != null && agent.path.corners.Length > 1)
        {
            // Set the Gizmo color to make the path more visible
            Gizmos.color = Color.blue;

            // Iterate over the path corners and draw lines between them
            for (int i = 0; i < agent.path.corners.Length - 1; i++)
            {
                // Draw a line between the current corner and the next
                Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
            }
        }
    }
}