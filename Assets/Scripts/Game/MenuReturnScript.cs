using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReturnScript : MonoBehaviour
{
    public string _menu;

    private void LoadMenu()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        Scene menuScene = SceneManager.GetSceneByName(_menu);
        SceneManager.SetActiveScene(menuScene);
        StartCoroutine(UnloadThisScene(activeScene));
    }

    IEnumerator UnloadThisScene(Scene scene)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.UnloadSceneAsync(scene);
    }

    private void OnEnable()
    {
        GameManagerScript.EndGame += LoadMenu;
    }

    private void OnDisable()
    {
        GameManagerScript.EndGame -= LoadMenu;
    }
}
