using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AuthController : MonoBehaviour
{
    public VerificationController verificationController;
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private GameObject AuthPanel;
    [SerializeField] private GameObject VerificationPanel;
    [SerializeField] private TMP_InputField numberField;

    // public string userNumber;

    public void Start()
    {
        WelcomePanel.SetActive(true);
        AuthPanel.SetActive(false);
        VerificationPanel.SetActive(false);
    }
    public void OnSubmitButtonClick()
    {
        string phoneNumber = numberField.text;

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            Debug.Log("OTP Sent successfully on your Registered Number.");
            VerificationPanel.SetActive(true);
            WelcomePanel.SetActive(false);
            AuthPanel.SetActive(false);

            verificationController.numberText.text = phoneNumber;
            verificationController.StartResendTimer();
        }
        else
        {
            Debug.Log("Please enter a valid mobile number!");
        }
    }
}
