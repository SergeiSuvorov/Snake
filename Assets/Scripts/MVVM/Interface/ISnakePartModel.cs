using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISnakePartModel 
{
    int EatCount { get; set; }
    int Speed { get; }
}
