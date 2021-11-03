using System.Collections;
using UnityEngine;


public class Character : MonoBehaviour
{
    [SerializeField] private CharacterTransparency _characterTransparency = null;
    [SerializeField] private CharacterVictory _characterVictory = null;


    private void Start()
    {
        _characterTransparency.BecomeTransparentNow();
        _characterTransparency.BecomeOpaque(this);
    }


    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FinishPortal finishPortal))
        {
            _characterVictory.FinishLevel(this, finishPortal);

            float timeBeforeDisappearance = 1f;
            yield return new WaitForSeconds(timeBeforeDisappearance);

            _characterTransparency.BecomeTransparent(this);
        }
    }
}