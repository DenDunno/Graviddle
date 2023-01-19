using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] [ChildGameObjectsOnly] private Panel[] _states;

    public void Show(Panel panel) 
    {
        HideAll();
        panel.Show();
    }

    public void Show<T>() where T : Panel
    {
        Show(Find<T>());
    }

    public void HideAll()
    {
        _states.ForEach(state => state.Hide());
    }

    private T Find<T>() where T : Panel
    {
        foreach (Panel uiState in _states)
        {
            if (uiState is T result)
            {
                return result;
            }
        }

        throw new Exception("No such ui component");
    }
}