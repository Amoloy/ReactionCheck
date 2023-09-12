using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data_SpeedTest
{
    private static List<float> _times = new List<float>();
    public static int _missesCount { get; private set; } = 0;

    public static float[] GetMass()
    {
        return _times.ToArray();
    }

    public static void UpdateMisses(int misses)
    {
        _missesCount = misses;
    }

    public static int Count()
    {
        return _times.Count;
    }

    public static float GetTotalTime()
    {
        float total = 0;

        foreach (float value in _times)
        {
            total += value;
        }

        return total;
    }

    public static float Get(int position)
    {
        if (position >= 0 && position < _times.Count)
        {
            return _times[position];
        }

        return 0;
    }

    public static void Add(float time)
    {
        _times.Add(time);
    }

    public static void OverwriteMass(List<float> list)
    {
        _times = new List<float>();

        foreach (float value in list)
        {
            _times.Add(value);
        }
    }
}
