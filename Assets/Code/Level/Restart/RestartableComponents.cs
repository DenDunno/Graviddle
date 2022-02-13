using System.Collections.Generic;


public class RestartableComponents
{
    public readonly IEnumerable<IRestart> RestartComponents;
    public readonly IEnumerable<IAfterRestart> AfterRestartComponents;
    public readonly IEnumerable<RestartableTransform> RestartTransforms;

    
    public RestartableComponents(IEnumerable<IRestart> restartComponents, IEnumerable<IAfterRestart> afterRestartComponents,
        IEnumerable<RestartableTransform> restartTransforms)
    {
        RestartComponents = restartComponents;
        AfterRestartComponents = afterRestartComponents;
        RestartTransforms = restartTransforms;
    }
}