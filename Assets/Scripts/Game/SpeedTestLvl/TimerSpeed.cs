using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpeed : MonoBehaviour
{
    private float _time = 0;
    private bool _process = false;
    private int _numberRecord;
    private int _count;

    public delegate void Action();
    public static event Action AllRecorded;

    private void StartRecording()
    {
        _numberRecord++;

        if (_numberRecord <= _count)
        {
            _process = true;
            //StartCoroutine(Record());
        }

        else
        {
            AllRecorded.Invoke();
            Data_SpeedTest.UpdateMisses(GameObject.FindGameObjectWithTag("missesCounter").GetComponent<MissesCounter>()._count);
        }
    }

    private void StopRecording()
    {
        _process = false;
        Data_SpeedTest.Add(_time);

        ResetTime();
    }

    private void ResetTime()
    {
        _time = 0f;
    }

    private void Update()
    {
        if (_process)
        {
            _time += Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        _numberRecord = 0;
        _count = GameObject.FindGameObjectWithTag("spawner").GetComponent<SpawnerSpeed>().count;

        SpawnerSpeed.StartSpawn += StartRecording;
        TargetScript.OnClick += StopRecording;
        TargetScript.OnClick += StartRecording;

    }

    private void OnDisable()
    {
        SpawnerSpeed.StartSpawn -= StartRecording;
        TargetScript.OnClick -= StopRecording;
        TargetScript.OnClick -= StartRecording;
    }


}
