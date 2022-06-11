using GraviddleSocketClient;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Analytics : ISubscriber
{
    private readonly WinState _winState;
    private readonly GraviddleClient _graviddleClient = new GraviddleClient();
    private float _clock;
    
    public Analytics(WinState winState)
    {
        _winState = winState;
    }

    public void Init()
    {
        _clock = Time.time;
    }

    void ISubscriber.Subscribe()
    {
        _winState.CharacterWon += OnCharacterWon;
    }

    void ISubscriber.Unsubscribe()
    {        
        _winState.CharacterWon -= OnCharacterWon;
    }

    private void OnCharacterWon()
    {        
        _graviddleClient.SendDataForAnalytics(new DataForAnalytics()
        {
            DeviceId = SystemInfo.deviceUniqueIdentifier,
            Name = "Denis",
            Age = 19,
            Level = SceneManager.GetActiveScene().buildIndex,
            TimeForLevel = Time.time - _clock,
            Stars = 2
        });
    }
}