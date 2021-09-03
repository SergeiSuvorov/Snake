using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEat
{
    event Action onCollision;
    GameObject Eat { get; }
}
