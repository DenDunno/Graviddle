using System.Collections;
using System.Linq;
using UnityEngine;


public class WinEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _starsParticles;
    [SerializeField] private ParticleSystem _sunEffect;
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private Reward _reward;

    private float _starsCoolDown;


    private void Start()
    {
        const float coolDown = 0.5f;
        _starsCoolDown = _starsParticles.First().main.duration + coolDown;
    }
    

    public IEnumerator ActivateEffects()
    {
        int stars = _reward.CollectedStars;

        for (var starIndex = 0; starIndex < stars; ++starIndex)
        {
            yield return StartCoroutine(ActivateStar(starIndex));
        }

        if (stars == 3)
        {
            PlaySpecialEffects();
        }
    }


    private void PlaySpecialEffects()
    {
        _confetti.gameObject.SetActive(true);
    }


    private IEnumerator ActivateStar(int starIndex)
    {
        _starsParticles[starIndex].gameObject.SetActive(true);
        yield return new WaitForSeconds(_starsCoolDown);
        _sunEffect.gameObject.SetActive(true);
    }
}