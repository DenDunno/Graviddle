using System.Collections;
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
        _starsCoolDown = _starsParticles[0].main.duration + coolDown;
    }
    

    public IEnumerator ActivateEffects()
    {
        int stars = _reward.GetStars();

        yield return StartCoroutine(ActivateStar(0));

        _sunEffect.gameObject.SetActive(true);

        for (int starIndex = 1; starIndex < stars; ++starIndex)
        {
            yield return StartCoroutine(ActivateStar(starIndex));
        }

        if (stars == 3)
        {
            _confetti.gameObject.SetActive(true);
        }
    }


    private IEnumerator ActivateStar(int starIndex)
    {
        _starsParticles[starIndex].gameObject.SetActive(true);
        yield return new WaitForSeconds(_starsCoolDown);
    }
}