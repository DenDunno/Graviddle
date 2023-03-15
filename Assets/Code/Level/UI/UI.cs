using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] [ChildGameObjectsOnly] private Panel[] _states;
    private Panel _current;

    public async UniTask Init()
    {
        foreach (Panel panel in _states)
        {
            await panel.Init();
        }
    }

    public async void ShowSync(Panel panel) // editor button
    {
        await Show(panel);
    }
    
    public async UniTask Show<T>() where T : Panel
    {
        await Show(Find<T>());
    }
    
    private async UniTask Show(Panel panel)
    {
        if (_current != null)
        {
            await _current.Hide();
        }

        _current = panel;
        
        await panel.Show();
    }
    
    public void DisableAll()
    {
        _states.ForEach(state => state.Disable());
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