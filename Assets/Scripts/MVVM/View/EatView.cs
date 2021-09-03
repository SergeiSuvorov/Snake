using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatView : MonoBehaviour, IEat
{
    public GameObject Eat => gameObject;

    public event Action onCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollision?.Invoke();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        onCollision?.Invoke();
    }
}
