using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 2f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
    }
}
