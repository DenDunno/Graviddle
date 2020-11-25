using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    private Image _deathImage;
    private Character _character;

    private void Start()
    {
        _deathImage = GetComponent<Image>();
        _character = FindObjectOfType<Character>();
    }


    public IEnumerator MakeFade()
    {
        yield return StartCoroutine(ChangeAlphaChannel(2, false, _deathImage)); // затемнение

        _character.Restart(); // когда экран черный, делаем все нужные "сбросы" 

        yield return new WaitForSeconds(0.7f);
        yield return StartCoroutine(ChangeAlphaChannel(-1.5f, true, _deathImage)); // осветление
    }


    public static IEnumerator ChangeAlphaChannel(float speedOfFading, bool dark, Image image)
    {
        while (dark ? image.color.a >= 0 : image.color.a <= 1)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + speedOfFading * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
