using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatManager 
{
    private IGameObjectFactory _eatFactory;
    private GameObject _eat;
    private float _boardMinX;
    private float _boardMaxX;
    private float _boardMinY;
    private float _boardMaxY;
    public EatManager(float boardMinX, float boardMaxX, float boardMinY, float boardMaxY)
    {
        _boardMaxX = boardMaxX;
        _boardMaxY = boardMaxY;
        _boardMinX = boardMinX;
        _boardMinY = boardMinY;

        CreateEat();
    }

    public void CreateEat()
    {
        _eatFactory = new EatFactory();
        _eat = _eatFactory.Create();

        _eat.GetComponent<IEat>().onCollision += SetEatCoordinate;

        SetEatCoordinate();
    }

    private void SetEatCoordinate()
    {
        float xPosition = Random.Range(_boardMinX, _boardMaxX);
        float yPosition = Random.Range(_boardMinY, _boardMaxY);

        Vector2 NewPosition = new Vector2(xPosition, yPosition);
        _eat.transform.position = NewPosition;
    }
}
