using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFactory: IGameObjectFactory
{
    private GameObject _prefab;

    public EatFactory()
    {
        _prefab = Resources.Load<GameObject>("Prefab/Eat");
    }

    public GameObject Create(Vector2 Position = new Vector2())
    {
        GameObject eat = Object.Instantiate(_prefab);
        return eat;
    }

}
