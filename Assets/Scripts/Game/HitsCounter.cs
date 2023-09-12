using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsCounter : CounterAbstract
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _text = "Hits:";
        TargetScript.OnClick += IncreaseCount;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        TargetScript.OnClick -= IncreaseCount;
    }
}
