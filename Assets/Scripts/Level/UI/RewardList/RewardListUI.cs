using UnityEngine;


public class RewardListUI : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement = null;
   

    private void Update()
    {
        if (_characterMovement.MoveDirection != Vector2.zero)
        {

        }
    }
}
