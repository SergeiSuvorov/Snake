using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CountView _countView;
    [SerializeField] private Transform _boardLeft;
    [SerializeField] private Transform _boardRight;
    [SerializeField] private Transform _boardTop;
    [SerializeField] private Transform _boardDown;
    [SerializeField] private CanvasController _canvasController;
    [SerializeField] private ListExecuteObject _listExecuteObject;
    [SerializeField] private GameObject _walls;
    private Snake _snake;
    private EatManager _eatManager;
    private InputController _inputController;


    private void Awake()
    {
        _canvasController.Initialize(this);
        _canvasController.ActivateStartMenu();
    }
    public void StartGame(int speed)
    {
        _walls.SetActive(true);

        float boardLeft = _boardLeft.position.x + _boardLeft.lossyScale.x / 2;
        float boardRight = _boardRight.position.x - _boardRight.lossyScale.x / 2;
        float boardDown = _boardDown.position.y + _boardDown.lossyScale.y / 2;
        float boardTop = _boardTop.position.y - _boardTop.lossyScale.y / 2;

        _inputController = new InputController(this);
        _listExecuteObject.AddToList(_inputController);

        _snake = new Snake(_countView, speed);
        _snake.GameOver+= GameEnd;
        _listExecuteObject.AddToList(_snake);
       
        _eatManager = new EatManager(boardLeft, boardRight, boardDown, boardTop);
    }

   
    public void Move(Vector2 direction)
    {
        _snake.SnakeHeadMove(direction);
    }

    private void GameEnd()
    {
        _snake.GameOver -= GameEnd;
        _listExecuteObject.DeleteFromList(_snake);
        _listExecuteObject.DeleteFromList(_inputController);
        _canvasController.ActivateEndBanner();
    }
}
