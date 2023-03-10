using UnityEngine;
using UnityEngine.UI;

public class UIBlocker : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    public void Enable()
    {
        _image.raycastTarget = true;
    }

    public void Disable()
    {
        _image.raycastTarget = false;
    }
}
