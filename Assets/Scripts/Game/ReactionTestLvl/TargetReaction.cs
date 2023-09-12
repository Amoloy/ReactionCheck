using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReaction : TargetScript
{
    public float _timeAlife { get; private set; }

    public static event Action OnDissapear;

    public TargetReaction()
    {
        _timeAlife = 1f;
    }

    public TargetReaction(float timeAlife)
    {
        _timeAlife = timeAlife;
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void FixMiss()
    {
        base.FixMiss();

        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(_timeAlife);

        OnDissapear?.Invoke();

        Destroy(gameObject);


        yield break;
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
