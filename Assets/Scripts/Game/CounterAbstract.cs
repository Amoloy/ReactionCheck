using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CounterAbstract : MonoBehaviour
{
    public int _count { get; protected set; }

    protected Text _textHandler;
    protected string _text;

    protected void IncreaseCount()
    {
        _count++;

        Show();
    }

    protected void Activation()
    {
        gameObject.SetActive(true);
    }

    protected void Deactivation()
    {
        gameObject.SetActive(false);
    }

    protected void Show()
    {
        _textHandler.text = _text + " " + _count.ToString();
    }

    protected virtual void OnEnable()
    {
        _count = 0;
        _textHandler = gameObject.GetComponent<Text>();

        GameManagerScript.StartGame += Show;
        SpawnerReaction.StartSpawn += Activation;
        GameManagerScript.EndGame += Deactivation;
    }

    protected virtual void OnDisable()
    {
        GameManagerScript.StartGame -= Show;
        SpawnerReaction.StartSpawn -= Activation;
        GameManagerScript.EndGame -= Deactivation;
    }
}
