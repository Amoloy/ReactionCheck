using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBackground : MonoBehaviour
{
    private void SetNonActive()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Countdown.CountdownEnd += SetNonActive;
    }

    private void OnDisable()
    {
        Countdown.CountdownEnd -= SetNonActive;
    }
}
