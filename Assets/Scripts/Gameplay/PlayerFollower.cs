using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float attackDistance;
    private NavMeshAgent _aiAgent;
    private Transform _playerReference;

    private static readonly int IsStopped = Animator.StringToHash("IsStopped");

    // Start is called before the first frame update
    void Start()
    {
        _aiAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerReference)
        {
            return;
        }
        _aiAgent.destination = _playerReference.position;
        float dist = Vector3.Distance(transform.position, _aiAgent.destination);
        
        animator.SetBool(IsStopped, dist < attackDistance);
    }

    public void SetTarget(Transform target)
    {
        _playerReference = target;
    }

    public bool CanReachPlayer()
    {
        float dist = Vector3.Distance(transform.position, _aiAgent.destination);
        return dist < attackDistance;
    }
}
