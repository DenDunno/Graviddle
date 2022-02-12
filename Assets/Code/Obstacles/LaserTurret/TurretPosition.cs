using UnityEngine;


public class TurretPosition : MonoBehaviour
{
    [SerializeField] private Transform _turret;
    [SerializeField] private Transform _anchor;


    public void Update()
    {
        _turret.position = _anchor.position;
    }
}