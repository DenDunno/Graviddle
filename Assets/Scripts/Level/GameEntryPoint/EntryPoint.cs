using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private CharacterStatesTransitionsFactory _characterStatesTransitionsFactory;
    
    
    private void Start()
    {
        var characterStates = new CharacterStatesPresenter(_character);

        _characterStatesTransitionsFactory.Init(_character, characterStates);

        CharacterStateTransitions characterStateTransitions = _characterStatesTransitionsFactory.Create();
    }
}