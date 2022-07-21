using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private float movementTimer=1;
    private Vector2Int snakePosition;
    // Start is called before the first frame update
    private int snakeDirection = 0;
    void Start()
    {
        snakePosition = new Vector2Int(0,0);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (snakeDirection != 2)
            {
                snakeDirection = 0; //0=up
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (snakeDirection != 3)
            {
                snakeDirection = 1; //1=right
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (snakeDirection != 0)
            {
                snakeDirection = 2; //2=down
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (snakeDirection != 1)
            {
                snakeDirection = 3; //3=left
            }
        }
      

        movementTimer -= Time.deltaTime;
       
        if(movementTimer <= 0)
        {
            movementTimer = 1;
            timerEnded();
            
        }
        
    }
    void timerEnded()
    {
        if(snakeDirection==0 && snakeDirection!= 2 )
        {
            snakePosition.y += 1;
            
        }
       
        if (snakeDirection == 1 && snakeDirection != 3)
        {
            snakePosition.x += 1;
            
        }
        if (snakeDirection == 2 && snakeDirection != 0)
        {
            snakePosition.y -= 1;
            
        }
        if (snakeDirection == 3 && snakeDirection != 1)
        {
            snakePosition.x -= 1;
            
        }
        transform.position = new Vector2(snakePosition.x, snakePosition.y);
        return;


    }
}
