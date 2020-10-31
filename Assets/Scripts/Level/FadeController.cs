using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    private Image death_image;
    private Character character;


    private void Start()
    {
        death_image = GetComponent<Image>();
        character = FindObjectOfType<Character>();
    }


    public IEnumerator Make_Fade()
    {
        yield return StartCoroutine(Change_alpha_channel(2, false, death_image)); // затемнение

        character.Restart(); // когда экран черный, делаем все нужные "сбросы" 

        yield return new WaitForSeconds(0.7f);
        yield return StartCoroutine(Change_alpha_channel(-1.5f, true, death_image)); // осветление
    }


    public static IEnumerator Change_alpha_channel(float speed_of_fading, bool dark, Image image)
    {
        while (dark ? image.color.a >= 0 : image.color.a <= 1)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + speed_of_fading * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
