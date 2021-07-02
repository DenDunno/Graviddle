using UnityEngine;
using UnityEngine.Events;


public class Character : MonoBehaviour , IRestartableObject
{
    [SerializeField] private UnityEvent Died = null;
    [SerializeField] private UnityEvent Respawned = null;
    [SerializeField] private Transform _startPosition = null;


    private void Awake()
    {
        CharacterStates.Init(this , Died);
    }


    void IRestartableObject.Restart()
    {
        transform.position = _startPosition.position;
        transform.rotation = _startPosition.rotation;

        Respawned?.Invoke();
    }
}



