using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform playerReference;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackDistance;
    private NavMeshAgent AIAgent;

    private static readonly int IsStopped = Animator.StringToHash("IsStopped");

    // Start is called before the first frame update
    void Start()
    {
        AIAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        AIAgent.destination = playerReference.position;
        float dist = Vector3.Distance(transform.position, AIAgent.destination);
        
        animator.SetBool(IsStopped, dist < attackDistance);
    }

    public bool CanReachPlayer()
    {
        float dist = Vector3.Distance(transform.position, AIAgent.destination);
        return dist < attackDistance;
    }
}
