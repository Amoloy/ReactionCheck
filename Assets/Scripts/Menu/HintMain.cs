using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintMain : Hint
{
    private void OnEnable()
    {
        SceneController.LoadNoChoosenLvl += Show;
    }

    private void OnDisable()
    {
        SceneController.LoadNoChoosenLvl -= Show;
    }
}
