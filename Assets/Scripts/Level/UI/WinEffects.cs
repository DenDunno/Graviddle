using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class WinEffects : MonoBehaviour
{
    [SerializeField] private Button[] _buttons = null;
    [SerializeField] private ParticleSystem[] _stars = null;
    [SerializeField] private ParticleSystem _sunEffect = null;
        

    public void ActivateEffects()
    {
        foreach (Button button in _buttons)
        {
            button.interactable = true;
        }

        _sunEffect.gameObject.SetActive(true);
    }
}
