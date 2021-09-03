using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface ICanvasStartViewModel 
{
    ReactiveProperty<int> SpeedCount { get; }

    void AddSnakeSpeed();

    void DeleteSnakeSpeed();

    void StartGame();
    event Action<int> GameStart;
}
