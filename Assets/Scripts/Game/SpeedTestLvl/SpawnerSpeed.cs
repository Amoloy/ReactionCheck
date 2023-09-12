using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpeed : MonoBehaviour
{
    public GameObject _target;
    public GameObject _invisibleWall;
    public float maxScaleRange;
    public int count;

    public delegate void Action();
    public static event Action StartSpawn;
    public static event Action EndSpawn;

    public void StartSpawning()
    {
        StartSpawn?.Invoke();
        Instantiate(_invisibleWall, new Vector3(0, 0, 0.1f), Quaternion.identity);

        float randomRange;
        for (int i = 0; i < count; i++)
        {
            randomRange = Random.Range(0, maxScaleRange);
            _target.GetComponent<Transform>().localScale = new Vector3(1 + randomRange, 1 + randomRange, 1);
            Instantiate(_target, new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 4f)), Quaternion.identity);
        }

        EndSpawn?.Invoke();
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
