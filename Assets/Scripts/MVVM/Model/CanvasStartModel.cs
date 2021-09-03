using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStartModel : ICanvasStartModel
{
    public CanvasStartModel ()
    {
        Speed = 1;
    }

    public int Speed { get; set; }

}
