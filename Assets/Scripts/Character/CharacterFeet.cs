using System.Linq;
using UnityEngine;


public class CharacterFeet : MonoBehaviour
{
    [SerializeField] private CollisionsList _centralFeetPart = null;
    [SerializeField] private CollisionsList[] _sideFeetParts = null;


    public bool CheckIfGrounded()
    {
        bool isCentreGrounded = _centralFeetPart.CheckComponent<Ground>();

        return _sideFeetParts.Any(partOfFeet => partOfFeet.CheckComponent<Ground>()) && isCentreGrounded;
    }
}