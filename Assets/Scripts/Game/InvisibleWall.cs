using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    public delegate void ActionWithWall();
    public static event ActionWithWall OnClick;

    protected virtual void OnMouseDown()
    {
        OnClick?.Invoke();
    }

    
}
