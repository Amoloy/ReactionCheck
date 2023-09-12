using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLvlState : MonoBehaviour
{
    public string GameLevelName;
    public bool _isChoosen { get; private set; } = false;

    private Color activeColor = new Color(0.57f, 0.88f, 0.57f);
    private Color inactiveColor = new Color(1f, 1f, 1f);
    private Image _image;

    public delegate void OnChangeHandler(string name, bool choosen);
    public static event OnChangeHandler OnChange;

    public delegate void OffOthersHandler();
    public event OffOthersHandler OffOthers;

    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
    }

    public void OnClick()
    {
        ChangeState();

        OffOthers?.Invoke();
        OnChange?.Invoke(GameLevelName, _isChoosen);
    }

    private void ChangeState()
    {
        _isChoosen = !_isChoosen;

        if (_isChoosen)
        {
            _image.color = activeColor;
        }

        else _image.color = inactiveColor;
    }

    public void UnChoose()
    {
        _isChoosen = false;
        _image.color = inactiveColor;
    }
}
