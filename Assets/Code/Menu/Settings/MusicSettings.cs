using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private const string _musicVolume = "MusicVolume";

    private void Start()
    {
        _slider.SetValueWithoutNotify(PlayerPrefs.GetFloat(_musicVolume));
    }
    
    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnValueChanged);
    }
    
    private void OnValueChanged(float newValue)
    {
        AudioListener.volume = newValue;
        PlayerPrefs.SetFloat(_musicVolume, newValue);
    }
}