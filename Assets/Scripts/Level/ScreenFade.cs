using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    private Image _deathImage;
    private Character _character;
    private SpriteRenderer _characterSprite;

    private void Start()
    {
        _deathImage = GetComponent<Image>();
        _character = FindObjectOfType<Character>();
        _characterSprite = _character.GetComponentInChildren<SpriteRenderer>();
    }


    public IEnumerator MakeFade()
    {
        StartCoroutine(Obstacle.SwitchOff()); // во время респауна персонаж неуязвим
        yield return StartCoroutine(ChangeAlphaChannel(2, true, (result) => { _deathImage.color = result; })); // затемнение

        _character.Restart(); // когда экран черный, делаем все нужные "сбросы" 

        yield return new WaitForSeconds(0.7f);
        yield return StartCoroutine(ChangeAlphaChannel(-1.5f, false, (result) => { _deathImage.color = result; })); // осветление
        yield return StartCoroutine(ChangeAlphaChannel(1.5f, true, (result) => { _characterSprite.color = result; })); // респаун
    }


    public static IEnumerator ChangeAlphaChannel(float speedOfFading, bool glassy, System.Action<Color> callback)
    {
        float alphaChannel = glassy ? 0 : 1;

        while (glassy ? alphaChannel <= 1 : alphaChannel >= 0)
        {
            alphaChannel += speedOfFading * Time.deltaTime;
            callback(new Color(255, 255, 255, alphaChannel));
            yield return new WaitForFixedUpdate();
        }
    }
}
