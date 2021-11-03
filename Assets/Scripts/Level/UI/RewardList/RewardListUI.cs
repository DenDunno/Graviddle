using TMPro;
using UnityEngine;


public class RewardListUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldUI = null;
    [SerializeField] private TMP_Text _silverUI = null;


    public void SetRewardListUI(int gold , int silver)
    {
        _goldUI.text = gold.ToString();
        _silverUI.text = silver.ToString();
    }
}
