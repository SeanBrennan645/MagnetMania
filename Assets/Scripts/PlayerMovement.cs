using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float maxDist = 0.0f;
    [SerializeField][Range(0.0f, 10.0f)] float maxSpeed = 10.0f;
    [SerializeField] [Range(0.0f, 10.0f)] float chargeAmount = 0.0f; //Can make private in future

    private bool onLeft = true;
    private bool isMoving = false;

    void Start()
    {
        
    }

    void Update()
    {
        CheckPlayerInput();
        Move();
    }

    private void Move()
    {
        if(onLeft && isMoving)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            if(transform.position.x >= maxDist)
            {
                isMoving = false;
            }
        }
        else if(!onLeft && isMoving)
        {
            transform.position += transform.right * -speed * Time.deltaTime;
            if(transform.position.x <= -maxDist)
            {
                isMoving = false;
            }
        }
    }

    private void CheckPlayerInput()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isMoving)
        {
            isMoving = true;
            onLeft = !onLeft;
        }
    }
}
