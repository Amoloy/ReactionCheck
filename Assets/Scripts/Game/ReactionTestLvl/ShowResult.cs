using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
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
        bool isHit;

        for (int i = 0; i < Data_ReactionTest.Count(); i++)
        {
            time = Data_ReactionTest.Get(i)._time;
            isHit = Data_ReactionTest.Get(i)._hit;

            if(i % 2 == 1)
            {
                text += i+1 + ". time: " + string.Format("{0:0.00}", time) + " hitted: " + isHit.ToString() + "\n";
            }
            else
            {
                text += i+1 + ". time: " + string.Format("{0:0.00}", time) + " hitted: " + isHit.ToString() + "   ";
            }
        }

        _textHandler.text = text;
    }
}
