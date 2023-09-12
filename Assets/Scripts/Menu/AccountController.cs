using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountController : MonoBehaviour
{
    public delegate void Action();

    public static event Action EnteringSuccess;
    public static event Action EnteringFail;

    public string _name { get; private set; }

    private void ChangeText(string name)
    {
        _name = name;
    }

    public void Check()
    {
        if(_name == "" || _name == null)
        {
            EnteringFail?.Invoke();
        }

        else
        {
            EnteringSuccess?.Invoke();
        }
    }

    private void OnEnable()
    {
        InputFIeldMsgSender.OnTextChange += ChangeText;
    }

    private void OnDisable()
    {
        InputFIeldMsgSender.OnTextChange -= ChangeText;
    }
}
