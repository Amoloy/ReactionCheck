using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFIeldMsgSender : MonoBehaviour
{
    private InputField field;

    public delegate void Action(string msg);
    public static event Action OnTextChange;

    private void Start()
    {
        field = gameObject.GetComponent<InputField>();
        field.onEndEdit.AddListener(OnChange);
    }

    private void OnChange(string text)
    {
        OnTextChange?.Invoke(field.text);
    }
}
