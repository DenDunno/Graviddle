
public abstract class TogglingComponent : IUpdate, ILateUpdate
{
    public bool IsActive = true;
    
    void IUpdate.Update()
    {
        if (IsActive)
        {
            OnUpdate();
        }
    }

    public void LateUpdate()
    {
        if (IsActive)
        {
            OnLateUpdate();
        }
    }

    protected virtual void OnUpdate() {}
    protected virtual void OnLateUpdate() {}
}