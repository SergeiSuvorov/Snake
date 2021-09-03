using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController :  IExecute
{
    private  GameController _gameController;

    public InputController(GameController gameController)
    {
        _gameController = gameController;
    }

   
    private Vector2 CheckInput()
    {

        Vector2 vector = new Vector2();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vector = Vector2.up ;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vector = Vector2.down ;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vector = Vector2.left ;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            vector = Vector2.right ;
        }

        return vector;
    }

    public void Execute()
    {
        Vector2 moveDirection = CheckInput();
        _gameController.Move(moveDirection);
    }
}
