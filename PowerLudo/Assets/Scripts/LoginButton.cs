using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    [SerializeField] private GameObject LoginPanel;
    [SerializeField] private GameObject FormPanel;
    [SerializeField] private GameObject verificationPanel;

    public void OnLoginButtonClick()
    {
        FormPanel.SetActive(true);
        LoginPanel.SetActive(false);
        verificationPanel.SetActive(false);
    }
}
