using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePartView : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SnakePartViewModel _snakePartVeiwModel;
    public SnakePartViewModel SnakePartViewModel => _snakePartVeiwModel;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Initialize(SnakePartViewModel snakePartViewModel)
    {
        _snakePartVeiwModel = snakePartViewModel;
        _rigidbody = GetComponent<Rigidbody2D>();
        float spriteSize = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        snakePartViewModel.SetParametrs(_rigidbody, spriteSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _snakePartVeiwModel.CheckCollision(collision);
    }
}
