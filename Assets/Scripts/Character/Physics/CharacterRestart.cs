using UnityEngine;


public class CharacterRestart : IRestart, IAfterRestart 
{
    private readonly EventTransit _characterResurrected = new EventTransit();


    public bool CheckRestart()
    {
        return _characterResurrected.CheckIfEventHappened();
    }


    void IRestart.Restart()
    {
        _characterResurrected.Invoke();
    }

    
    void IAfterRestart.Restart()
    {
    }
}