using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class FinishIconSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _finishIcon = null;
    private SpriteRenderer _finishPortal;


    private void Start()
    {
        _finishPortal = GetComponent<SpriteRenderer>();
    }


    public void Update()
    {
        _finishIcon.gameObject.SetActive(_finishPortal.isVisible == false);
    }
}