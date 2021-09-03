using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CanvasStartViewModel :  ICanvasStartViewModel
{
    public ReactiveProperty<int> SpeedCount { get; }
    private ICanvasStartModel _model;

    public event Action<int> GameStart;

    public CanvasStartViewModel()
    {
        _model = new CanvasStartModel ();
        SpeedCount = new ReactiveProperty<int>(_model.Speed);
    }

    public void AddSnakeSpeed()
    {
        _model.Speed++;
        SpeedCount.Value= _model.Speed;
    }

    public void DeleteSnakeSpeed()
    {
        if (_model.Speed > 1)
        {
            _model.Speed--;
            SpeedCount.Value = _model.Speed;
        }
    }

    public void StartGame()
    {
        GameStart?.Invoke(_model.Speed);
    }
}
