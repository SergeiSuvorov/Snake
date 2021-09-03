using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadViewModel : SnakePartViewModel
{
    public Action GameOver;
    public SnakeHeadViewModel(ISnakePartModel model) : base(model)
    {
    }

    private float CheckDistance()
    {
        float distance = ((Vector2)_rigidbody.transform.position - _lastPosition).magnitude;
        if (distance > _spriteSize)
        {
            Vector2 direction = ((Vector2)_rigidbody.position - _lastPosition).normalized;
            SetLastPosition(_lastPosition + direction * _spriteSize);
            distance -= _spriteSize;
        }
        return distance;
    }
    public void MoveSnakeHead(Vector2 moveDirection)
    {
        _move.MoveSnakeHead(moveDirection, _rigidbody, Model.Speed);
    }

    public void MoveSnakeTail()
    {
        float distance = CheckDistance();

        if (_nextPart != null)
        {
            _nextPart.MoveSnakeTail(_lastPosition, distance);
        }
    }
    public override void CheckCollision(Collision2D collision)
    {
        base.CheckCollision(collision);
       
        if (collision.gameObject.TryGetComponent<SnakePartView>(out SnakePartView snakePartView))
        {
            if ((snakePartView.SnakePartViewModel as SnakePartViewModel) != _nextPart)
            {
                GameEnd();
            }
        }
        if (collision.gameObject.GetComponent<WallMark>() != null)
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        _rigidbody.velocity = Vector2.zero;
        GameOver?.Invoke();
    }
}
