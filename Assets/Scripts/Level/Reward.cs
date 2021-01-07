using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Reward : MonoBehaviour
{
    [SerializeField]
    private int _silverReward = 5;

    [SerializeField]
    private int _goldReward = 2;

    [SerializeField]
    private GameObject _pauseButton = null;

    [SerializeField]
    private ParticleSystem _starParicles = null;

    private void Start()
    {
        Texture2D rewardTex = DefineReward();
        Sprite rewardSprite = Sprite.Create(rewardTex, new Rect(0, 0, rewardTex.width, rewardTex.height), Vector2.zero);
        GetComponent<Image>().sprite = rewardSprite;

        _pauseButton.SetActive(false);
    }


    private Texture2D DefineReward()
    {
        int result = GravityChangeType.NumOfRotations;
        string answer;

        if (result > _silverReward)
        {
            answer = "Bronze";
        }

        else if (result > _goldReward && result <= _silverReward)
        {
            answer = "Silver";
        }

        else
        {
            answer = "Gold";
            _starParicles.gameObject.SetActive(true);
        }

        int currentScene = SceneManager.GetActiveScene().buildIndex - 3; // 3 - количество "менюшных" сцен
        SaveSystem.MakeSave(currentScene, answer);

        return Resources.Load<Texture2D>("UI/Cup/" + answer);
    }

}
