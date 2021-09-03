using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _endBanner;
    private GameController _gameController;
    private ICanvasStartViewModel _viewModel;

    public void Initialize(GameController gameController)
    {
        _gameController = gameController;
    }
    
    public void ActivateStartMenu()
   {
        _startMenu.SetActive(true);

        if(_viewModel==null)
        {
            CreateCanvasStartViewModel();
        }
   }

    private void CreateCanvasStartViewModel()
    {
        _viewModel = new CanvasStartViewModel();
        _viewModel.GameStart += StartGame;
        StartCanvasView view = _startMenu.GetComponent<StartCanvasView>();
        view.Initialize(_viewModel);
    }

    private void StartGame(int speedCount)
    {
        DeactivateStartMenu();
        _gameController.StartGame(speedCount);
    }
    public void DeactivateStartMenu()
    {
        _startMenu.SetActive(false);
    }

    public void ActivateEndBanner()
    {
        _endBanner.SetActive(true);
    }
}
