using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerReaction : MonoBehaviour
{
    private float _time = 0;
    private bool _process = false;
    private bool _isHit;

    private float step = 0.01f;

    private void StartRecording()
    {
        _process = true;
        StartCoroutine(Record());
    }

    private void StopRecording()
    {
        _process = false;
    }

    IEnumerator Record()
    {
        while (_process)
        {
            _time += Time.deltaTime;
            yield return new WaitForSeconds(step);
        }

        Data_ReactionTest.Add(_time, _isHit);

        ResetTime();
    }

    private void ResetTime()
    {
        _time = 0f;
    }

    private void Hit()
    {
        _isHit = true;
    }

    private void Miss()
    {
        _isHit = false;
    }

    private void OnEnable()
    {
        SpawnerReaction.OnSpawn += StartRecording;

        TargetScript.OnClick += StopRecording;
        TargetScript.OnMiss += StopRecording;
        TargetReaction.OnDissapear += StopRecording;

        TargetScript.OnClick += Hit;
        TargetScript.OnMiss += Miss;
        TargetReaction.OnDissapear += Miss;
    }

    private void OnDisable()
    {
        SpawnerReaction.OnSpawn -= StartRecording;

        TargetScript.OnClick -= StopRecording;
        TargetScript.OnMiss -= StopRecording;
        TargetReaction.OnDissapear -= StopRecording;

        TargetScript.OnClick -= Hit;
        TargetScript.OnMiss -= Miss;
        TargetReaction.OnDissapear -= Miss;
    }

}
