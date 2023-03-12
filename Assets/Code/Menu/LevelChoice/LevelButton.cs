using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Image[] _stars;
    [SerializeField] private Image[] _nonStars;
    [SerializeField] private Image _lockImage;
    [SerializeField] private Button _button;

    public void Init(UIBlocker uiBlocker)
    {
        _button.onClick.AddListener(uiBlocker.Enable);
    }
    
    public void SetStars(int stars)
    {
        _nonStars.ForEach(nonStar => nonStar.gameObject.SetActive(true));
        
        for (int i = 0; i < stars; i++)
        {
            _stars[i].gameObject.SetActive(true);
            _nonStars[i].gameObject.SetActive(false);
        }
    }

    public void UnlockLevel()
    {
        _lockImage.gameObject.SetActive(false);
        _button.interactable = true;
    }
}