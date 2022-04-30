using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float fallSpeed = 1.0f;
    [SerializeField] float resetSpeed = 1.0f;
    [SerializeField] float maxDist = 0.0f;
    [SerializeField] float chargeRate = 0.2f;
    [SerializeField][Range(0.0f, 10.0f)] float maxSpeed = 10.0f;

    private bool onLeft = true;
    private bool isMoving = false;
    private bool isCharging = false;

    void Start()
    {
        Mathf.Clamp(speed, 1.0f, maxSpeed);
    }

    void Update()
    {
        CheckPlayerInput();
        Move();
        if(isCharging)
        {
            Charge();
        }
    }

    private void CheckPlayerInput()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isMoving)
        {
            isCharging = true;
        }
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) && !isMoving)
        {
            isCharging = false;
            isMoving = true;
            onLeft = !onLeft;
        }
    }

    private void Move()
    {
        if(onLeft && isMoving)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            if(transform.position.x >= maxDist)
            {
                isMoving = false;
                speed = 1.0f;
            }
        }
        else if(!onLeft && isMoving)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
            if(transform.position.x <= -maxDist)
            {
                isMoving = false;
                speed = 1.0f;
            }
        }

        if(!isMoving && !isCharging/* && (transform.position.y <= 0)*/)
        {
            transform.position += transform.up * resetSpeed * Time.deltaTime;
        }
    }

    private void Charge()
    {
        //TODO Implement a system to have fall speed accerlate over time
        speed += chargeRate * Time.deltaTime;
        transform.position -= transform.up * fallSpeed * Time.deltaTime;
    }

    
}
