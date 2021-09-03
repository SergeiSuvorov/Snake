using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    float MinStep { get; set; }
    void MoveSnakeHead(Vector2 moveDirection, Rigidbody2D rigidbody, float Speed);
    void MoveSnakeTail(Vector2 nextPosition, Vector2 lastPosition, Rigidbody2D rigidbody, float turn);
}
