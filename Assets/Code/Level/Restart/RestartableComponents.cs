using System.Collections.Generic;

public class RestartableComponents
{
    public readonly IEnumerable<IRestart> RestartComponents;
    public readonly IEnumerable<IAfterRestart> AfterRestartComponents;

    public RestartableComponents(IEnumerable<IRestart> restartComponents, IEnumerable<IAfterRestart> afterRestartComponents)
    {
        RestartComponents = restartComponents;
        AfterRestartComponents = afterRestartComponents;
    }
}