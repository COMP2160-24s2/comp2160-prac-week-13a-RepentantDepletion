using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI; // Added for AI package

[RequireComponent(typeof(NavMeshAgent))] // Added RequireComponent for NavMeshAgent
public class MovePlayerNavMesh : MonoBehaviour
{
    private PlayerActions playerActions;
    private InputAction mousePosition;
    private InputAction mouseClick;

    [SerializeField] private float speed = 5;
    [SerializeField] private LayerMask layerMask;
    private Vector3 destination;
    private NavMeshAgent agent; // Added private NavMeshAgent variable

    void Awake()
    {
        playerActions = new PlayerActions();
        mousePosition = playerActions.Movement.Position;
        mouseClick = playerActions.Movement.Click;
    }

    void OnEnable()
    {
        mousePosition.Enable();
        mouseClick.Enable();
    }

    void OnDisable()
    {
        mousePosition.Disable();
        mouseClick.Disable();
    }

    void Start()
    {
        mouseClick.performed += GetDestination;
        destination = transform.position;
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
    }

    private void GetDestination(InputAction.CallbackContext context)
    {
        Vector2 position = mousePosition.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            destination = hit.point;
            agent.SetDestination(destination); // Set destination using NavMeshAgent
        }
    }        
}