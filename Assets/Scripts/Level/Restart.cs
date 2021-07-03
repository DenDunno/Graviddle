using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Backstage))]
public class Restart : MonoBehaviour
{
    [SerializeField] private UnityEvent AfterRestart = null;
    private IEnumerable<IRestartableComponent> _restartableComponents = null;
    private readonly float _restartTime = 0.7f;
    private Backstage _backstage;


    private void Start()
    {
        _restartableComponents = FindObjectsOfType<MonoBehaviour>().OfType<IRestartableComponent>();        
        _backstage = GetComponent<Backstage>();
    }


    public void ActivateRestart() // called by character death event
    {
        StartCoroutine(MakeRestart());
    }


    private IEnumerator MakeRestart()
    {
        yield return StartCoroutine(_backstage.MakeFade(RestartObjects()));
        AfterRestart?.Invoke();
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
