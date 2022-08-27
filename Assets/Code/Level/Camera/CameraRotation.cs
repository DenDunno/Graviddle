using UnityEngine;


public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Character _character;
    private readonly float _speed = 6f;


    private void LateUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation , _character.transform.rotation , _speed * Time.deltaTime);
    }
}
