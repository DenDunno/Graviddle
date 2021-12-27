using UnityEngine;
using UnityEngine.UI;


public abstract class ButtonClick : MonoBehaviour
{
    [SerializeField] private Button _button = null;


    public void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }


    public void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }


    protected abstract void OnButtonClick();
}