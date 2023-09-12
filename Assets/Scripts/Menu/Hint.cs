using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Hint : MonoBehaviour
{
    public float _time;
    public string _text;

    protected Text _textHandler;

    protected void Show()
    {
        _textHandler.text = _text;
        StartCoroutine(AutoClearText());
    }

    IEnumerator AutoClearText()
    {
        yield return new WaitForSeconds(_time);

        _textHandler.text = "";
    }

    private void Start()
    {
        _textHandler = gameObject.GetComponent<Text>();
    }
}
