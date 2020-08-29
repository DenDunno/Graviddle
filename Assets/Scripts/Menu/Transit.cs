using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Transit : MonoBehaviour
{
    [SerializeField]
    private Image Transition_image = null;


    private void Start()
    { 
        DontDestroyOnLoad(gameObject);
    }
    

    public void SpawnTransit(int scene)
    {
        Instantiate(this).ActivateTransit(scene);   
    }


    public void ActivateTransit(int scene)
    {
        StartCoroutine(Make_Transition(scene));
    }


    private  IEnumerator Make_Transition(int scene)
    {
        AsyncOperation loading_menu_scene = SceneManager.LoadSceneAsync(scene);
        loading_menu_scene.allowSceneActivation = false;

        yield return StartCoroutine(Fade_controller.Change_alpha_channel(2, false, Transition_image));

        yield return new WaitUntil(() => loading_menu_scene.progress >= 0.9f);
        loading_menu_scene.allowSceneActivation = true;

        yield return StartCoroutine(Fade_controller.Change_alpha_channel(-2, true, Transition_image));


        Destroy(gameObject);
    }
}

