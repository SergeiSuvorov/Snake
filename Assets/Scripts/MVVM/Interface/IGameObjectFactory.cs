using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameObjectFactory 
{
    GameObject Create(Vector2 Position = new Vector2());
}
