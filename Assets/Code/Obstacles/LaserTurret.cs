using UnityEngine;


public class LaserTurret : MonoBehaviour
{
    [SerializeField] private Transform _turret;
    [SerializeField] private Transform _turretAnchor;
    [SerializeField] private Transform _fastening;
    [SerializeField] private CharacterHead _target;
    private IUpdatable[] _updatables;


    public void Init(CurrentGravityData currentGravityData)
    {
        var turretRotationData = new TurretRotationData(_target, _turret, 1.5f);
        var fasteningRotationData = new TurretRotationData(_target, _fastening, 2f);
        
        _updatables = new IUpdatable[]
        {
            new TurretPosition(_turret, _turretAnchor),
            new TurretRotation(turretRotationData),
            new TurretFasteningRotation(fasteningRotationData, currentGravityData, transform)
        };
    }


    private void Update()
    {
        _updatables.UpdateForEach();
    }
}
