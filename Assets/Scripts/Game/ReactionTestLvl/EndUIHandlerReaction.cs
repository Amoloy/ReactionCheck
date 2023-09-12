using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUIHandlerReaction : MonoBehaviour
{
    public GameObject BackButton;
    public GameObject ResultsText;

    private void ActivateButton()
    {
        BackButton.SetActive(true);
    }

    private void ShowResult()
    {
        ResultsText.GetComponent<ShowResult>().Show();
    }

    private void OnEnable()
    {
        SpawnerReaction.EndSpawn += ActivateButton;
        SpawnerReaction.EndSpawn += ShowResult;
    }

    private void OnDisable()
    {
        SpawnerReaction.EndSpawn -= ActivateButton;
        SpawnerReaction.EndSpawn -= ShowResult;
    }
}
