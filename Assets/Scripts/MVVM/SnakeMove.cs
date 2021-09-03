using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : IMove
{
    private Vector2 _nextDirection;
    private Vector2 _direction;
    private Vector2 _lastPosition;
    public float MinStep { get; set; }

    public SnakeMove()
    {
        MinStep = 0.0f;
        _direction = Vector2.zero;
        _lastPosition = Vector2.zero;
    }

    public void MoveSnakeHead(Vector2 moveDirection, Rigidbody2D rigidbody, float Speed)
    {
        CheckParametrs(moveDirection, rigidbody);
         rigidbody.velocity = _direction * Speed;
    }

    public void MoveSnakeTail(Vector2 nextPosition, Vector2 lastPosition, Rigidbody2D rigidbody, float turn)
    {
        rigidbody.transform.position = Vector2.Lerp(lastPosition, nextPosition, turn);
    }

    private void CheckParametrs(Vector2 moveDirection, Rigidbody2D rigidbody)
    {
        if (_lastPosition == Vector2.zero)
        {
            _lastPosition = rigidbody.transform.position;
        }
        if (_direction == Vector2.zero)
        {
            _direction = _nextDirection;
        }
        if (moveDirection != Vector2.zero && moveDirection != -_nextDirection && moveDirection != -_direction)
        {
            _nextDirection = moveDirection;
        }
        if (((Vector2)rigidbody.transform.position - _lastPosition).magnitude > MinStep)
        {
            _direction = _nextDirection;
            _lastPosition = rigidbody.transform.position;
        }
    }
   
}
