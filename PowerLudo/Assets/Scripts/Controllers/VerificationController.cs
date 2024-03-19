using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VerificationController : MonoBehaviour
{
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private GameObject AuthPanel;
    [SerializeField] private GameObject VerificationPanel;
    [SerializeField] private TMP_InputField[] otpInputFields;
    public TMP_Text numberText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text secText;
    [SerializeField] private TMP_Text ResendButton;
    private int NextSceneIndex = 2;

    private const int OTP_LENGTH = 6; // Length of OTP
    private const float MAX_TIMER_DURATION = 60f; // Maximum duration of the timer
    private float currentTimer = MAX_TIMER_DURATION;
    private bool isTimerRunning = false;

    private void Start()
    {
        WelcomePanel.SetActive(true);
        AuthPanel.SetActive(false);
        VerificationPanel.SetActive(false);
        // timerText.gameObject.SetActive(false); // Hide timer text initially
        // secText.gameObject.SetActive(false);
        // ResendButton.gameObject.SetActive(false); // Hide resend button initially
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTimer -= Time.deltaTime;
            UpdateTimerText();

            if (currentTimer <= 0)
            {
                isTimerRunning = false;
                ShowResendButton();
            }
        }
    }

    private void UpdateTimerText()
    {
        int seconds = Mathf.CeilToInt(currentTimer);
        timerText.text = seconds.ToString();
        secText.text = "Sec";
    }

    private void ShowResendButton()
    {
        ResendButton.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        secText.gameObject.SetActive(false);
    }

    public void OnVerifyButtonClick()
    {
        // Concatenate OTP from input fields
        string enteredOTP = "";
        for (int i = 0; i < otpInputFields.Length; i++)
        {
            enteredOTP += otpInputFields[i].text;
        }

        // Check if entered OTP is correct
        if (enteredOTP.Length == OTP_LENGTH)
        {
            // Assume static OTP for now
            string staticOTP = "123456"; // Change this to your static OTP

            if (enteredOTP == staticOTP)
            {
                Debug.Log("OTP verified successfully!");
                SceneManager.LoadSceneAsync(NextSceneIndex);
            }
            else
            {
                Debug.Log("Incorrect OTP! Please try again.");
                // Optionally, you can clear the input fields here for the user to enter OTP again
                StartResendTimer();
            }
        }
        else
        {
            Debug.Log("Please enter a valid OTP!");
        }
    }

    public void OnClickEditBtn()
    {
        WelcomePanel.SetActive(false);
        AuthPanel.SetActive(true);
        VerificationPanel.SetActive(false);
        StartResendTimer();
    }

    public void ResendOTP()
    {
        StartResendTimer();
        ResendButton.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
        secText.gameObject.SetActive(true);
    }

    public void StartResendTimer()
    {
        currentTimer = MAX_TIMER_DURATION;
        isTimerRunning = true;
        UpdateTimerText();
    }
}
