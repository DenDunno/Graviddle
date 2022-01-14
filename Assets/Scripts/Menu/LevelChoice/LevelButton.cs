using MPUIKIT;
using UnityEngine;
using UnityEngine.UI;


public class LevelButton : MonoBehaviour
{
    [SerializeField] private Image[] _stars;
    [SerializeField] private MPImage _lockImage;


    public void SetStars(int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            _stars[i].gameObject.SetActive(true);
        }
    }


    public void UnlockLevel()
    {
        _lockImage.gameObject.SetActive(false);
    }
}