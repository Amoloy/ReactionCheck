using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissesCounter : CounterAbstract
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _text = "Misses:";
        InvisibleWall.OnClick += IncreaseCount;
        TargetReaction.OnDissapear += IncreaseCount;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        InvisibleWall.OnClick -= IncreaseCount;
        TargetReaction.OnDissapear -= IncreaseCount;
    }
}
