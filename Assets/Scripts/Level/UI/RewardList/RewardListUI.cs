using TMPro;
using UnityEngine;


public class RewardListUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldUI;
    [SerializeField] private TMP_Text _silverUI;


    public void SetRewardListUI(int gold , int silver)
    {
        _goldUI.text = gold.ToString();
        _silverUI.text = silver.ToString();
    }
}
