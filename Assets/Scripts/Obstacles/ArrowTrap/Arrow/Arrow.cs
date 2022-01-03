using UnityEngine;


public class Arrow : MonoBehaviour
{
    [SerializeField] private ArrowTrail _arrowTrail = null;
    [SerializeField] private ArrowMovement _arrowMovement = null;

    public ArrowTrail Trail => _arrowTrail;
    public ArrowMovement Movement => _arrowMovement;
}