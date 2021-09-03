using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExecuteObject: MonoBehaviour
{
    private List<IExecute> _listExecuteObject;

    public void AddToList(IExecute execute)
    {
        if (_listExecuteObject == null)
        {
            _listExecuteObject = new List<IExecute>();
        }
            _listExecuteObject.Add(execute);
    }

    public void DeleteFromList(IExecute execute)
    {
        if (_listExecuteObject == null)
            return;
        _listExecuteObject.Remove(execute);
    }

    private void Update()
    {
        if (_listExecuteObject == null)
        {
                return;
        }

        for (var i = 0; i < _listExecuteObject.Count; i++)
        {
            var interactiveObject = _listExecuteObject[i];
            interactiveObject.Execute();
        }
    }
}
