using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResultSpeed : MonoBehaviour
{
    private Text _textHandler;

    private void Start()
    {
        _textHandler = gameObject.GetComponent<Text>();
    }

    public void Show()
    {
        string text = "";
        float time;

        for (int i = 0; i < Data_SpeedTest.Count(); i++)
        {
            time = Data_SpeedTest.Get(i);

            if (i % 2 == 1)
            {
                text += i + 1 + ". time: " + string.Format("{0:0.00}", time) + "\n";
            }
            else
            {
                text += i + 1 + ". time: " + string.Format("{0:0.00}", time) + "   ";
            }
        }

        _textHandler.text = text;
    }
}
