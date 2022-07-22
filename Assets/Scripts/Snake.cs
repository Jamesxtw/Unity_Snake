using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private float movementTimer;
    private Vector2 snakePosition;
    private Vector3 snakeDirection ;
    private float snakeSpeed ;
    private Vector2 snakeInputDirection ;
    
    void Start()
    {
        movementTimer = 1;
        snakePosition = new Vector2(0,0);
        snakeSpeed = 0.5f;
        snakeInputDirection = new Vector2(0, 0);
        snakeDirection = new Vector3(0,snakeSpeed,0);
        snakePosition = new Vector2(snakeDirection.x, snakeDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        InputCheck();
    }

    void Timer()
    {
        movementTimer -= Time.deltaTime;
        if (movementTimer <= 0)
        {
            movementTimer = 1;
            timerEnded();
        }
    }

    void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            snakeInputDirection.x = 0;
            snakeInputDirection.y = snakeSpeed;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            snakeInputDirection.x = snakeSpeed;
            snakeInputDirection.y = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            snakeInputDirection.x = 0;
            snakeInputDirection.y = -snakeSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            snakeInputDirection.x = -snakeSpeed;
            snakeInputDirection.y = 0;
        }
    }

    void timerEnded()
    {

        if (snakeInputDirection.x == 0 && snakeInputDirection.y == snakeSpeed)
        {
            if (snakeDirection.y != -snakeSpeed)
            {
                snakeDirection.x = 0;
                snakeDirection.y = snakeSpeed;
                snakeDirection.z = 0;

            }
        }
        if (snakeInputDirection.x == snakeSpeed && snakeInputDirection.y == 0)
        {
            if (snakeDirection.x != -snakeSpeed)
            {
                snakeDirection.x = snakeSpeed;
                snakeDirection.y = 0;
                snakeDirection.z = -90;
            }

        }
        if (snakeInputDirection.x == 0&& snakeInputDirection.y == -snakeSpeed)
        {
            if (snakeDirection.y != snakeSpeed)
            {
                snakeDirection.x = 0;
                snakeDirection.y = -snakeSpeed;
                snakeDirection.z = 180;
            }
        }
        if (snakeInputDirection.x == -snakeSpeed && snakeInputDirection.y == 0)
        {
            if (snakeDirection.x != snakeSpeed)
            {
                snakeDirection.x = -snakeSpeed;
                snakeDirection.y = 0;
                snakeDirection.z = 90;

            }
        }

        snakePosition.x = snakePosition.x + snakeDirection.x;
        snakePosition.y = snakePosition.y + snakeDirection.y;
        transform.position = new Vector2(snakePosition.x , snakePosition.y );
        transform.eulerAngles=new Vector3( 0 , 0 , snakeDirection.z );
        return;


    }
}
