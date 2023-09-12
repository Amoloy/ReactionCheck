using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonSctipt : MonoBehaviour
{
    public delegate void Action();
    public static event Action OnClick;

    public void InvokeOnClick()
    {
        OnClick?.Invoke();
    }
}
