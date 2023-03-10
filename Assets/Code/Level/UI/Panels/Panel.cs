using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    public virtual async UniTask Init()
    {
        await UniTask.Yield();
    }
    
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public async UniTask Show()
    {
        Enable();
        await OnShow();
    }

    public async UniTask Hide()
    {
        await OnHide();
        Disable();
    }

    protected virtual async UniTask OnShow() { await UniTask.Yield(); }

    protected virtual async UniTask OnHide() { await UniTask.Yield(); }
}