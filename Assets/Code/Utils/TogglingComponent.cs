
public abstract class TogglingComponent : IUpdate
{
    public bool IsActive = true;
    
    void IUpdate.Update()
    {
        if (IsActive)
        {
            OnUpdate();
        }
    }

    protected abstract void OnUpdate();
}