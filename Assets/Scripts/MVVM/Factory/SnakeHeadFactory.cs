using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadFactory : IGameObjectFactory
{
    private int _speed;
    private GameObject _prefab;
    private SnakePartModel model;
    public SnakeHeadFactory(int speed)
    {
        _speed = speed;
        _prefab = Resources.Load<GameObject>("Prefab/SnakePart");
        model = new SnakePartModel(_speed);
    }
    public GameObject Create(Vector2 Position = new Vector2())
    {
        _prefab.transform.position = Position;
        GameObject snakePart = Object.Instantiate(_prefab);
        SnakeHeadViewModel veiwModel = new SnakeHeadViewModel(model);
        var headTailView = snakePart.GetComponent<SnakePartView>();
        headTailView.Initialize(veiwModel);
        return snakePart;
    }
}
