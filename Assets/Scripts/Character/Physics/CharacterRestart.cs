using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterRestart : MonoBehaviour, IRestartableComponent 
{
    private Rigidbody2D _characterRigidbody;
    private readonly EventTransit _eventTransit = new EventTransit();

    
    private void Start()
    {
        _characterRigidbody = GetComponent<Rigidbody2D>();
    }


    public bool CheckIfResurrected()
    {
        return _eventTransit.CheckIfEventHappened();
    }


    void IRestartableComponent.Restart()
    {
        _eventTransit.Invoke();
        transform.SetParent(null);
        _characterRigidbody.velocity = Vector2.zero;
    }
}