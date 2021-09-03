using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CountView : MonoBehaviour
{
    private SnakePartViewModel _snakeViewModel;
    [SerializeField]private Text _countText;
    public void Initialize(SnakePartViewModel snakePartViewModel)
    {
        _snakeViewModel = snakePartViewModel;
        _snakeViewModel.EatCount 
            .ObserveEveryValueChanged(x => x.Value) 
            .Subscribe(xs => {RenderCount(xs); })
            .AddTo(this);
    }

    public void RenderCount(int count)
    {
        _countText.text = count.ToString();
    }

}
