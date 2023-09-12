using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintRegister : Hint
{
    private void OnEnable()
    {
        AccountController.EnteringFail += Show;
    }

    private void OnDisable()
    {
        AccountController.EnteringFail -= Show;
    }
}
