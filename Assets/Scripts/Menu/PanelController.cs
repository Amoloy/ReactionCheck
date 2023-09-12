using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject RegisterPanel, MainPanel;

    private void OnEnable()
    {
        AccountController.EnteringSuccess += ChangeRegisterState;
        AccountController.EnteringSuccess += ChangeMainState;

        SceneController.OnUnLoadAdditiveScene += ChangeMainState;
        SceneController.OnLoadAdditiveScene += ChangeMainState;
    }

    private void ChangeRegisterState()
    {
        if (RegisterPanel.activeSelf)
        {
            RegisterPanel.SetActive(false);
        }
        else RegisterPanel.SetActive(true);
    
    }

    private void ChangeMainState()
    {
        if (MainPanel.activeSelf)
        {
            MainPanel.SetActive(false);
        }
        else MainPanel.SetActive(true);
    }
}
