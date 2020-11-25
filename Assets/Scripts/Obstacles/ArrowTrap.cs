using System.Collections;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    private Arrow _arrow;

    private void Start()
    {
        _arrow = Resources.Load<Arrow>("Prefabs/Obstacles/Arrow");
        StartCoroutine(ArrowSpawn());
    }

    private IEnumerator ArrowSpawn()
    {
        while (true)
        {
            Instantiate(_arrow, transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
