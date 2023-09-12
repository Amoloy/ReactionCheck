using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public delegate void Action();

    public static event Action StartGame;
    public static event Action EndGame;

    private void Launch()
    {
        StartGame?.Invoke();
    }

    private void End()
    {
        EndGame?.Invoke();
    }

    private void OnEnable()
    {
        Countdown.CountdownEnd += Launch;
        BackButtonSctipt.OnClick += End;
    }

    private void OnDisable()
    {
        Countdown.CountdownEnd -= Launch;
        BackButtonSctipt.OnClick -= End;
    }
}
