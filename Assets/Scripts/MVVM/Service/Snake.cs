using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Snake : IExecute
{
    private SnakeHeadViewModel _snakeHeadViewModel;
    private Transform _snakeHead;
    private Transform _snakeTailEnd;
    private SnakePartFactory _snakeGameObjectFactory;
    public Action GameOver;

    public Snake(CountView countView, int speed)
    {
        _snakeGameObjectFactory = new SnakePartFactory(speed);
        CreateHead(countView); 
        AddCircle();
        AddCircle();
        AddCircle();
        _snakeHeadViewModel.SetStartPosition((Vector2)_snakeHead.position);
    }

    private void CreateHead(CountView countView)
    {
        GameObject head = _snakeGameObjectFactory.Create(SnakePart.Head);
        var headView = head.GetComponent<SnakePartView>();

        _snakeHeadViewModel = headView.SnakePartViewModel as SnakeHeadViewModel ;
        _snakeHeadViewModel.GetEat += AddCircle;
        _snakeHeadViewModel.GameOver += GameEnd;
        _snakeHead = head.transform;
        _snakeTailEnd = _snakeHead;

        countView.Initialize(_snakeHeadViewModel);
    }

    private void GameEnd()
    {
        _snakeHeadViewModel.GameOver-= GameEnd;
        GameOver?.Invoke();
    }

    public void SnakeHeadMove(Vector2 direction)
    {
        _snakeHeadViewModel.MoveSnakeHead(direction);
    }
    public void SnakeTailMove()
    {
        _snakeHeadViewModel.MoveSnakeTail();
    }

    public void AddCircle()
    {
        GameObject gameObject = _snakeGameObjectFactory.Create(SnakePart.Tail, _snakeTailEnd.position);
        var veiwModel = gameObject.GetComponent<SnakePartView>().SnakePartViewModel;
        veiwModel.GetEat += AddCircle;
        _snakeHeadViewModel.SetNextPart(veiwModel);

        gameObject.transform.parent = _snakeHead;
        gameObject.SetActive(true);
        _snakeTailEnd = gameObject.transform;
    }

    public void Execute()
    {
        SnakeTailMove();
    }
}
