using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Backstage))]
public class Restart : MonoBehaviour
{
    [SerializeField] private Character _character = null;

    private readonly float _restartTime = 0.7f;
    private Backstage _backstage;

    private IEnumerable<IRestartableComponent> _restartableComponents = null;
    private IEnumerable<IAfterRestartComponent> _afterRestartComponents = null;
    

    private void Start()
    {
        _restartableComponents = FindObjectsOfType<MonoBehaviour>().OfType<IRestartableComponent>();
        _afterRestartComponents = FindObjectsOfType<MonoBehaviour>().OfType<IAfterRestartComponent>();
        _backstage = GetComponent<Backstage>();
    }


    private void OnEnable()
    {
        _character.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _character.CharacterDied -= OnCharacterDied;
    }


    private void OnCharacterDied()
    {
        StartCoroutine(MakeRestart());
    }


    private IEnumerator MakeRestart()
    {
        yield return StartCoroutine(_backstage.MakeFade(RestartObjects()));

        foreach (IAfterRestartComponent afterRestartComponent in _afterRestartComponents)
        {
            afterRestartComponent.Restart();
        }
    }


    private IEnumerator RestartObjects()
    {
        foreach(IRestartableComponent restartableObject in _restartableComponents)
        {
            restartableObject.Restart();
        }
        
        yield return new WaitForSeconds(_restartTime);
    }
}
