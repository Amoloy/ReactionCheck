using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUIHandlerSpeed : MonoBehaviour
{
    public GameObject BackButton;
    public GameObject ResultsText;

    private void ActivateButton()
    {
        BackButton.SetActive(true);
    }

    private void ShowResult()
    {
        ResultsText.GetComponent<ShowResultSpeed>().Show();
    }

    private void OnEnable()
    {
        TimerSpeed.AllRecorded += ActivateButton;
        TimerSpeed.AllRecorded += ShowResult;
    }

    private void OnDisable()
    {
        TimerSpeed.AllRecorded -= ActivateButton;
        TimerSpeed.AllRecorded -= ShowResult;
    }
}
