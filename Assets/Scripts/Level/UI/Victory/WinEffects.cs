using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WinEffects : MonoBehaviour
{
    [SerializeField] private Button[] _buttons = null;
    [SerializeField] private ParticleSystem[] _stars = null;
    [SerializeField] private ParticleSystem _sunEffect = null;
    [SerializeField] private ParticleSystem _confetti = null;

    private float _delayBetweenStars = 0;


    private void Start()
    {
        float delay = 0.5f;
        _delayBetweenStars = _stars[0].main.duration + delay;
    }


    public void ActivateEffects()
    {
        foreach (Button button in _buttons)
        {
            button.interactable = true;
        }

        StartCoroutine(ActivateParticles());
    }
        

    private IEnumerator ActivateParticles()
    {
        int stars = 0;
        
        _stars[0].gameObject.SetActive(true);

        yield return new WaitForSeconds(_delayBetweenStars);

        _sunEffect.gameObject.SetActive(true);

        for (int i = 1; i < stars; ++i)
        {
            _stars[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(_delayBetweenStars);
        }

        if (stars == 3)
        {
            _confetti.gameObject.SetActive(true);
        }
    }
}
