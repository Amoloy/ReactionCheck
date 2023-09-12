using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallReaction : InvisibleWall
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        Destroy(gameObject);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        TargetScript.OnClick += SelfDestroy;
        TargetReaction.OnDissapear += SelfDestroy;
    }

    private void OnDisable()
    {
        TargetScript.OnClick -= SelfDestroy;
        TargetReaction.OnDissapear -= SelfDestroy;
    }
}
