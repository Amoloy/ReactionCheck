using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data_ReactionTest
{
    private static List<HitsResult> _times = new List<HitsResult>();

    public static HitsResult[] GetMass()
    {
        return _times.ToArray();
    }

    public static int Count()
    {
        return _times.Count;
    }

    public static int GetMissesCount()
    {
        int _misses = 0;

        foreach (HitsResult value in _times)
        {
            if (!value._hit)
            {
                _misses++;
            }
        }
        return _misses;
    }

    public static HitsResult Get(int position)
    {
        if(position >= 0 && position < _times.Count)
        {
            return new HitsResult(_times[position]._time, _times[position]._hit);
        }

        return null;
    }

    public static void Add(float time, bool hit)
    {
        _times.Add(new HitsResult(time, hit));
    }

    public static void OverwriteMass(List<HitsResult>list)
    {
        _times = new List<HitsResult>();

        foreach(HitsResult value in list)
        {
            _times.Add(value);
        }
    }
}
