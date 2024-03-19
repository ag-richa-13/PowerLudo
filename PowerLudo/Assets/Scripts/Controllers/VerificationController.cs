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

        // Add listener to each OTP input field for cursor iteration
        foreach (TMP_InputField inputField in otpInputFields)
        {
            inputField.onValueChanged.AddListener(delegate { OnInputValueChanged(inputField); });
        }
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

        // Clear the text of all OTP input fields
        foreach (TMP_InputField inputField in otpInputFields)
        {
            inputField.text = "";
        }
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

    private void OnInputValueChanged(TMP_InputField currentInputField)
    {
        // Find the index of the current input field
        int currentIndex = System.Array.IndexOf(otpInputFields, currentInputField);

        // If the current input field is not the first one and its length becomes zero, move focus to the previous input field
        if (currentIndex > 0 && currentInputField.text.Length == 0)
        {
            TMP_InputField previousInputField = otpInputFields[currentIndex - 1];
            previousInputField.Select();
            previousInputField.ActivateInputField();

            // Deselect the current input field to prevent the keyboard from opening automatically
            currentInputField.DeactivateInputField();
        }
        // If the current input field is not the last one and its length is equal to 1, move focus to the next input field
        else if (currentIndex < otpInputFields.Length - 1 && currentInputField.text.Length == 1)
        {
            TMP_InputField nextInputField = otpInputFields[currentIndex + 1];
            nextInputField.Select();
            nextInputField.ActivateInputField();

            // Deselect the current input field to prevent the keyboard from opening automatically
            currentInputField.DeactivateInputField();
        }
    }
}


