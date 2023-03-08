
public interface IGravityState
{
    GravityDirection Direction { get; }
    
    public GravityData Data => GravityDataPresenter.GravityData[Direction];
}