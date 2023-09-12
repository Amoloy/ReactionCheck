using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlsController : MonoBehaviour
{
    private List<GameObject> lvls = new List<GameObject>();

    public void ClearLvls()
    {
        lvls = new List<GameObject>();
    }

    private void OnEnable()
    {
        FindLvls();
        SubscribeLvls();
    }

    private void OnDisable()
    {
        UnsubscriveLvls();
        ClearLvls();
    }

    private void FindLvls()
    {
        GameObject[] mass = GameObject.FindGameObjectsWithTag("lvl");

        foreach(GameObject o in mass)
        {
            Add(o);
        }
    }

    private void SubscribeLvls()
    {
        for(int i = 0; i < lvls.Count; i++)
        {
            for (int j = 0; j < lvls.Count; j++)
            {
                if(i != j)
                {
                    lvls[i].GetComponent<ButtonLvlState>().OffOthers += lvls[j].GetComponent<ButtonLvlState>().UnChoose;
                }
            }
        }
    }

    private void UnsubscriveLvls()
    {
        for (int i = 0; i < lvls.Count; i++)
        {
            for (int j = 0; j < lvls.Count; j++)
            {
                if (i != j)
                {
                    lvls[i].GetComponent<ButtonLvlState>().OffOthers -= lvls[j].GetComponent<ButtonLvlState>().UnChoose;
                }
            }
        }
    }

    private void Add(GameObject obj)
    {
        lvls.Add(obj);
    }
}
