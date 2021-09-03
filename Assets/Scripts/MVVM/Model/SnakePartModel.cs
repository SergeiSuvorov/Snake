using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakePartModel : ISnakePartModel
{
    public int Speed { get; }
    public int EatCount { get; set; }

    public event Action GameOver;
    public event Action AddTail;

    public SnakePartModel(int speed)
    {
        Speed = speed;
        EatCount = 0;
    }
    public void onCollision(Collision2D collision)
    {
        GameOver?.Invoke();
    }
}
