using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public delegate void Action();
    public static event Action LoadNoChoosenLvl;

    public static event Action OnLoadAdditiveScene;
    public static event Action OnUnLoadAdditiveScene;

    private string _choosenScene;
    private bool _isChoosenLvl;

    public void LoadScene()
    {
        if (_isChoosenLvl)
        {
            OnLoadAdditiveScene?.Invoke();
            SceneManager.LoadSceneAsync(_choosenScene, LoadSceneMode.Additive);
            Scene additiveScene = SceneManager.GetSceneByName(_choosenScene);
            StartCoroutine(SetActiveScene(additiveScene));

            SceneManager.sceneUnloaded += AfterUnloadAdditive;
        }
        else
        {
            LoadNoChoosenLvl?.Invoke();
        }
    }

    private void AfterUnloadAdditive(Scene scene)
    {
        OnUnLoadAdditiveScene?.Invoke();
        SceneManager.sceneUnloaded -= AfterUnloadAdditive;
    }

    IEnumerator SetActiveScene(Scene scene)
    {
        while (!scene.isLoaded)
        {
            yield return new WaitForEndOfFrame();
        }
        SceneManager.SetActiveScene(scene);
    }

    private void ChooseLvl(string name, bool choosen)
    {
        _choosenScene = name;
        _isChoosenLvl = choosen;
    }

    private void OnEnable()
    {
        ButtonLvlState.OnChange += ChooseLvl;
    }

    private void OnDisable()
    {
        ButtonLvlState.OnChange -= ChooseLvl;
    }
}
