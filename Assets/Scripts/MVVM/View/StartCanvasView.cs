using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvasView : MonoBehaviour
{
    private ICanvasStartViewModel _canvasStartViewModel;
    [SerializeField]private Text _countText;
    public void OnAddButtonClick()
    {
        if (_canvasStartViewModel != null)
        {
            _canvasStartViewModel.AddSnakeSpeed();
        }
    }
    public void OnDeleteButtonClick()
    {
        if (_canvasStartViewModel!=null)
        {
            _canvasStartViewModel.DeleteSnakeSpeed();
        }
    }

    public void Initialize(ICanvasStartViewModel canvasStartViewModel)
    {
        _canvasStartViewModel = canvasStartViewModel;
        _canvasStartViewModel.SpeedCount
            .ObserveEveryValueChanged(x => x.Value)
            .Subscribe(xs => { RenderCount(xs); })
            .AddTo(this);
    }
    public void RenderCount(int count)
    {
        _countText.text = count.ToString();
    }

    public void StarGame()
    {
        if (_canvasStartViewModel != null)
        {
            _canvasStartViewModel.StartGame();
        }
    }

}
