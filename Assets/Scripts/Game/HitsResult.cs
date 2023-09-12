using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsResult
{
    public float _time { get; private set; }
    public bool _hit { get; private set; }

    public HitsResult(float time, bool hit)
    {
        _time = time;
        _hit = hit;
    }

}
