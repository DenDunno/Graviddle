using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ResetProgressButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        #if !UNITY_EDITOR
        gameObject.SetActive(false);
        #endif
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnResetButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnResetButtonClick);
    }

    private void OnResetButtonClick()
    {
        PlayerPrefs.DeleteAll();
    }
}