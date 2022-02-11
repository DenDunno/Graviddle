using UnityEngine;


public class CharacterMovementInEditor : MonoBehaviour
{
    private void Start()
    {
        #if !UNITY_EDITOR
        enabled = false;
        return;
        #endif
    }
}
