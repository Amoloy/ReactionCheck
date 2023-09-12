using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerReaction : MonoBehaviour
{
    public GameObject _target;
    public GameObject _invisibleWall;
    public float _timeExist;
    public float _scale;
    public int count;

    public delegate void Action();
    public static event Action StartSpawn;
    public static event Action EndSpawn;

    public static event Action OnSpawn;

    public void StartSpawning()
    {
        StartSpawn?.Invoke();
        StartCoroutine(SpawnProcess());
    }

    IEnumerator SpawnProcess()
    {
        TargetScript tg = _target.GetComponent<TargetScript>();
        tg = new TargetReaction(_timeExist);
        _target.GetComponent<Transform>().localScale = new Vector3(_scale, _scale, 1);

        for (int i = 0; i < count; i++)
        {
            OnSpawn?.Invoke();
            Instantiate(_target, new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 4f)), Quaternion.identity);
            Instantiate(_invisibleWall, new Vector3(0, 0, 0.1f), Quaternion.identity);

            yield return new WaitForSeconds(_timeExist + 0.01f);
        }


        EndSpawn?.Invoke();
        yield break;
    }

    private void OnEnable()
    {
        GameManagerScript.StartGame += StartSpawning;
    }

    private void OnDisable()
    {
        GameManagerScript.StartGame -= StartSpawning;
    }
}
