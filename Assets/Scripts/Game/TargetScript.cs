using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public delegate void Action();
    public static event Action OnClick;
    public static event Action OnMiss;

    protected virtual void OnMouseDown()
    {
        OnClick?.Invoke();

        Destroy(gameObject);
    }

    protected virtual void FixMiss()
    {
        OnMiss?.Invoke();
    }

    private void OnEnable()
    {
        InvisibleWall.OnClick += FixMiss;
    }

    private void OnDisable()
    {
        InvisibleWall.OnClick -= FixMiss;
    }
}
