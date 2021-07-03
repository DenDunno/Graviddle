using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour , IRestartableComponent
{
    [SerializeField] private UnityEvent Died = null;

    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        CharacterStates.Init(this , Died);

        _rigidbody = GetComponent<Rigidbody2D>();
    }


    void IRestartableComponent.Restart()
    {        
        _rigidbody.velocity = new Vector2(0, 0);
    }
}



