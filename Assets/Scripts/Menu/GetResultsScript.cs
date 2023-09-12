using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetResultsScript : MonoBehaviour
{
    public GameObject ReactionTest_Result;
    public GameObject SpeedTest_Result;
    public GameObject Conclusion;

    private Text _textHandler;

    private void OnEnable()
    {
        if (Check())
        {
            OutputAll();
        }
    }

    private bool Check()
    {
        return (Data_ReactionTest.Count() > 0) & (Data_SpeedTest.Count() > 0);
    }

    private void OutputAll()
    {
        OutputReactionTest();
        OutputSpeedTest();
        OutputConclusion();
    }

    private void OutputReactionTest()
    {
        _textHandler = ReactionTest_Result.GetComponent<Text>();

        string text = "";
        float time;
        bool isHit;

        for (int i = 0; i < Data_ReactionTest.Count(); i++)
        {
            time = Data_ReactionTest.Get(i)._time;
            isHit = Data_ReactionTest.Get(i)._hit;

            if (i % 2 == 1)
            {
                text += i + 1 + ". time: " + string.Format("{0:0.00}", time) + " hitted: " + isHit.ToString() + "\n";
            }
            else
            {
                text += i + 1 + ". time: " + string.Format("{0:0.00}", time) + " hitted: " + isHit.ToString() + "   ";
            }
        }

        _textHandler.text = text;
    }

    private void OutputSpeedTest()
    {
        _textHandler = SpeedTest_Result.GetComponent<Text>();

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

        text += "\n Total time: " + Data_SpeedTest.GetTotalTime();

        _textHandler.text = text;
    }

    private void OutputConclusion()
    {
        _textHandler = Conclusion.GetComponent<Text>();

        int mark = AnalyzeResults();

        _textHandler.text = GetMarkDescription(mark);
    }

    private int AnalyzeResults()
    {
        int mark = 0;

        int missesReaction = Data_ReactionTest.GetMissesCount();
        float totalTimeSpeed = Data_SpeedTest.GetTotalTime();
        int missesSpeed = Data_SpeedTest._missesCount;

        if (missesReaction == 0)
        {
            mark += 3;
        }
        else if(missesReaction >= 1 && missesReaction <= 2)
        {
            mark += 2;
        }
        else if(missesReaction >= 3 && missesReaction <= 5)
        {
            mark += 1;
        }

        if(totalTimeSpeed <= 5f)
        {
            mark += 2;
        }
        else if(totalTimeSpeed <= 10f)
        {
            mark += 1;
        }

        if(missesSpeed >= 0 && missesReaction <= 1)
        {
            mark += 1;
        }

        return mark;
    }

    private string GetMarkDescription(int mark)
    {
        string description = "";

        if (mark == 6)
        {
            description = "Perfect result. Nothing to worry about";
        }
        else if (mark == 5 || mark == 4)
        {
            description = "Good result. Nothing to worry about";
        }
        else if (mark == 3)
        {
            description = "Normal result. Next time try better";
        }
        else if (mark == 2 || mark == 1)
        {
            description = "Bad result. You can have some problems";
        }
        else if (mark == 0)
        {
            description = "Very bad result. You have problems";
        }

        return description;
    }
}
