using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePartFactory 
{
    private IGameObjectFactory _headFactory;
    private IGameObjectFactory _tailFactory;

    public SnakePartFactory(int speed)
    {
        _headFactory = new SnakeHeadFactory(speed);
        _tailFactory = new SnakeTailFactory(speed);
    }

    public GameObject Create(SnakePart snakePart, Vector2 Position = new Vector2())
    {
        GameObject gameObject;
        switch (snakePart)
        {
            case SnakePart.Head:
                gameObject = _headFactory.Create();
                break;
            case SnakePart.Tail:
                gameObject = _tailFactory.Create(Position);
                break;
            default:
                gameObject = _tailFactory.Create(Position);
                break;
        }
        return gameObject;
    }
}
public enum SnakePart
{
    Head =0,
    Tail=1
}
