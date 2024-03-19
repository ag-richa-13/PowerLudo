using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeButtonController : MonoBehaviour
{
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private GameObject AuthPanel;
    [SerializeField] private GameObject VerificationPanel;

    private void Start()
    {
        WelcomePanel.SetActive(true);
    }

    public void OnLoginButtonClick()
    {
        AuthPanel.SetActive(true);
        WelcomePanel.SetActive(false);
        VerificationPanel.SetActive(false);
    }
}
