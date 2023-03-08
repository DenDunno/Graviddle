using UnityEngine;

public abstract class Panel : MonoBehaviour, IToggleable
{
    public void Show()
    {
        gameObject.SetActive(true);
        OnShow();
    }

    public void Hide()
    {
        OnHide();
        gameObject.SetActive(false);
    }
    
    protected virtual void OnShow() {}
    protected virtual void OnHide() {}
}