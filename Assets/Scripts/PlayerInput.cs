using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            controller.MoveForward();
        }
        else if (Input.GetKey("s"))
        {
            controller.MoveBackward();
        }
        
        if (Input.GetKeyUp("s"))
        {
            controller.StopMovement();
        }
        
        if (Input.GetKeyUp("w"))
        {
            controller.StopMovement();
        }

        RaycastHit[] hits = new RaycastHit[1];
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.RaycastNonAlloc(ray, hits) > 0)
        {
            var mousePoint = hits[0].point;
            controller.RotateTo(mousePoint);
        }

        if (Input.GetMouseButtonDown(0))
        {
            controller.MeleeAttack();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            controller.RangeAttack();
        }
    }
}
