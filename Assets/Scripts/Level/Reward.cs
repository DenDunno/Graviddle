using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Reward : MonoBehaviour
{
    [SerializeField]
    private int bronze_reward = 5;

    [SerializeField]
    private int gold_reward = 2;



    private void Start()
    {
        Texture2D reward_tex = DefineReward();

        Sprite reward_sprite = Sprite.Create(reward_tex, new Rect(0, 0, reward_tex.width, reward_tex.height), Vector2.zero);

        GetComponent<Image>().sprite = reward_sprite;
    }


    private Texture2D DefineReward()
    {
        int result = Character.num_of_rotations;
        string answer;


        if (result > bronze_reward)
            answer = "Bronze";

        else if (result > gold_reward && result <= bronze_reward)
            answer = "Silver";

        else
            answer = "Gold";


        int currentScene = SceneManager.GetActiveScene().buildIndex - 3; // 3 - количество "менюшных" сцен
        SaveSystem.MakeSave(currentScene, answer);

        return Resources.Load<Texture2D>("Level/Cup/" + answer);
    }

}
