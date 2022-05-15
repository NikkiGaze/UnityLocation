using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float forwardSpeed;
    [SerializeField, Range(0, 1)] private float backwardSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController movementController;
    [SerializeField] private MeleeAttack meleeAttackController;
    [SerializeField] private RangeAttack rangeAttackController;
    [SerializeField] private HealthStats playerStats;
    
    private Vector3 _directionVector;
    private Vector3 _mousePoint;
    private float _speed;
    private static readonly int IsMoveForward = Animator.StringToHash("IsMoveForward");
    private static readonly int IsMoveBackward = Animator.StringToHash("IsMoveBackward");

    // Start is called before the first frame update
    void Start()
    {
        _directionVector = Vector3.forward;
        _speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movementController.Move(_directionVector.normalized * _speed);
        // transform.position = transform.position + _directionVector.normalized * _speed;
        RotateToMouse();
    }

    public void MoveForward()
    {
        _speed = forwardSpeed;
        animator.SetBool(IsMoveForward, true);
    }
    
    public void MoveBackward()
    {
        _speed = -backwardSpeed;
        animator.SetBool(IsMoveBackward, true);
    }
    
    public void StopMovement()
    {
        _speed = 0;
        animator.SetBool(IsMoveForward, false);
        animator.SetBool(IsMoveBackward, false);
    }

    public void RotateTo(Vector3 point)
    {
        _mousePoint = point;
    }

    public void MeleeAttack()
    {
        meleeAttackController.TryAttack();
    }
    
    public void RangeAttack()
    {
        rangeAttackController.TryAttack();
    }

    public void TakeBonus(BonusName bonusName, int value)
    {
        playerStats.TakeBonus(bonusName, value);
    }

    public void AddFrag()
    {
        playerStats.AddFrag();
    }

    private void RotateToMouse()
    {
        Vector2 angleDifferenceDirection = new Vector2(_mousePoint.x - transform.position.x, 
            _mousePoint.z - transform.position.z).normalized;
        Vector2 forward = new Vector2(transform.forward.x, transform.forward.z);
        float angle = Vector2.SignedAngle(angleDifferenceDirection, forward);;
        transform.eulerAngles = transform.eulerAngles + Vector3.up * angle;
        _directionVector = Quaternion.AngleAxis(angle, Vector3.up) * _directionVector;
        _directionVector.y = 0;
    }
}
