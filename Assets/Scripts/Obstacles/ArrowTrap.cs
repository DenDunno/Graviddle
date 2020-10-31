using System.Collections;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    private Arrow arrow;

    private void Start()
    {
        arrow = Resources.Load<Arrow>("Prefabs/Obstacles/Arrow");
        StartCoroutine(Arrow_spawn());
    }

    private IEnumerator Arrow_spawn()
    {
        while (true)
        {
            Instantiate(arrow, transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
