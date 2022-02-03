using UnityEngine;
using UnityEngine.UI;


public class TransitButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    private readonly EventTransit _eventTransit = new EventTransit();


    public bool CheckIfPressed() => _eventTransit.CheckIfEventHappened();
    
    public void OnButtonPressed() => _eventTransit.Invoke();
}