using System.Collections;
using System.Linq;
using UnityEngine;


public class WinEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _starsParticles;
    [SerializeField] private ParticleSystem _sunEffect;
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private Reward _reward;
    [SerializeField] private AudioSource _victoryMusic;

    private float _starsCoolDown;


    private void Start()
    {
        const float coolDown = 0.5f;
        _starsCoolDown = _starsParticles.First().main.duration + coolDown;
    }
    

    public IEnumerator ActivateEffects()
    {
        int collectedStars = _reward.CollectedStars;

        for (var starIndex = 0; starIndex < collectedStars; ++starIndex)
        {
            yield return StartCoroutine(ActivateStar(starIndex));
        }

        if (collectedStars == _reward.MaxStars)
        {
            PlaySpecialEffects();
        }
    }


    private void PlaySpecialEffects()
    {
        _confetti.gameObject.SetActive(true);
        _victoryMusic.Play();
    }


    private IEnumerator ActivateStar(int starIndex)
    {
        _starsParticles[starIndex].gameObject.SetActive(true);
        yield return new WaitForSeconds(_starsCoolDown);
        _sunEffect.gameObject.SetActive(true);
    }
}