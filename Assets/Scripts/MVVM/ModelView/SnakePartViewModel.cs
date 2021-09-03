using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public  class SnakePartViewModel
{

    protected ISnakePartModel Model { get; }
    public ReactiveProperty<int> EatCount { get; private set; }
    protected IMove _move;
    protected float _spriteSize;
    protected Rigidbody2D _rigidbody;
    protected Vector2 _lastPosition;
    protected SnakePartViewModel _nextPart;

    public Action GetEat;

    public SnakePartViewModel(ISnakePartModel model)
    {
        Model = model;
        _move = new SnakeMove();
        EatCount = new ReactiveProperty<int>(Model.EatCount);
    }

    public void MoveSnakeTail(Vector2 nextPosition, float distance)
    {
        _move.MoveSnakeTail(nextPosition, _lastPosition, _rigidbody, distance / _spriteSize);
        if (_nextPart != null)
        {
            _nextPart.MoveSnakeTail(_lastPosition, distance);
        }
    }

    protected void SetLastPosition(Vector2 lastPosition)
    {
        if (_nextPart != null)
        {
            _nextPart.SetLastPosition(_lastPosition);
        }
        _lastPosition = lastPosition;
    }

    public virtual void CheckCollision(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IEat>() != null)
        {
            Model.EatCount++;
            EatCount.Value = Model.EatCount;
            GetEat?.Invoke();
        }
    }

    public void SetNextPart(SnakePartViewModel nextPart)
    {
        if (_nextPart != null)
        {
            _nextPart.SetNextPart(nextPart);
        }
        else
        {
            _nextPart = nextPart;
        }
    }

    public virtual void SetStartPosition(Vector2 startPosition)
    {
        var ofset = new Vector2(0, -_spriteSize);
        _lastPosition = startPosition;
        _rigidbody.transform.position = startPosition;
        startPosition += ofset;
        if (_nextPart != null)
        {
            _nextPart.SetStartPosition(startPosition);
        }
    }
    public void SetParametrs(Rigidbody2D rigidbody, float spriteDiameter)
    {
        _rigidbody = rigidbody;
        _lastPosition = rigidbody.position;
        _spriteSize = spriteDiameter;
        _move.MinStep = spriteDiameter;
    }
   
}
