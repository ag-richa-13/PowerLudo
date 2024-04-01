using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeButtonController : MonoBehaviour
{
    public AuthUIManager authUIManager;
    public AuthController authController;
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private GameObject AuthPanel;
    [SerializeField] private GameObject VerificationPanel;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private GameObject successPanel;

    private void Start()
    {
        WelcomePanel.SetActive(true);
        AuthPanel.SetActive(false);
        VerificationPanel.SetActive(false);
        errorPanel.SetActive(false);
        successPanel.SetActive(false);
    }

    public void OnLoginButtonClick()
    {
        AuthPanel.SetActive(true);
        WelcomePanel.SetActive(false);
        VerificationPanel.SetActive(false);
        errorPanel.SetActive(false);
        successPanel.SetActive(false);

        authController.numberField.text = "";

    }
}
