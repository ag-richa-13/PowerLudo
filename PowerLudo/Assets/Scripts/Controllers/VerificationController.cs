using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VerificationController : MonoBehaviour
{
    public AuthUIManager authUIManager;
    public VerificationUIManager verificationUIManager;
    //Intialized for strat funtion and edit button and also for Error and Success Panel
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private GameObject AuthPanel;
    [SerializeField] private GameObject VerificationPanel;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private GameObject successPanel;

    //array for input fields
    public TMP_InputField[] otpInputFields;

    //To print userNumber;
    public TMP_Text numberText;

    //verify buttton
    public Sprite originalColor;
    public Sprite transparentColor;
    [SerializeField] private Button VerifyButton;

    //works for timer and resend button
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text secText;
    [SerializeField] private TMP_Text ResendButton;
    private const float MAX_TIMER_DURATION = 60f;
    private float currentTimer = MAX_TIMER_DURATION;
    private bool isTimerRunning = false;

    //Error and success pop up
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private TMP_Text successrText;

    //Next SceneIndex
    private int NextSceneIndex = 2;

    //OTP Length
    private const int OTP_LENGTH = 6;

    private void Start()
    {

        //start function working when application will starts
        WelcomePanel.SetActive(true);
        AuthPanel.SetActive(false);
        VerificationPanel.SetActive(false);
        errorPanel.SetActive(false);
        successPanel.SetActive(false);

        VerifyButton.image.sprite = transparentColor;
        foreach (TMP_InputField inputField in otpInputFields)
        {
            inputField.onValueChanged.AddListener(OnValueChanged);
        }
    }

    //working for timer
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

    private void OnValueChanged(string text)
    {
        bool isOtpEmpty = false;
        foreach (TMP_InputField inputField in otpInputFields)
        {
            if (string.IsNullOrEmpty(inputField.text))
            {
                isOtpEmpty = true;
                break;
            }
        }

        if (isOtpEmpty)
        {
            VerifyButton.image.sprite = originalColor;
        }
        else
        {
            VerifyButton.image.sprite = transparentColor;
        }
    }

    public void OnVerifyButtonClick()
    {
        // Check if any OTP input field is empty
        bool isOtpEmpty = false;
        foreach (TMP_InputField inputField in otpInputFields)
        {
            if (string.IsNullOrEmpty(inputField.text))
            {
                isOtpEmpty = true;
                break;
            }
        }

        if (isOtpEmpty)
        {
            ShowErrorMessage("Please enter OTP");
            return;
        }

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
                ShowSuccessPopup();
                StartCoroutine(DeactivatePopup(successPanel, 3f));
                SceneManager.LoadSceneAsync(NextSceneIndex);
            }
            else
            {
                Debug.Log("Incorrect OTP! Please try again.");
                ShowErrorMessage("Incorrect OTP! Please try again!");
                StartResendTimer();
            }
        }
        else
        {
            Debug.Log("Please enter a valid OTP!");
            ShowErrorMessage("Please enter a valid OTP!");
        }
    }

    private void ShowErrorMessage(string message)
    {
        errorText.text = message;
        errorPanel.SetActive(true);
        StartCoroutine(DeactivatePopup(errorPanel, 3f));
    }

    private void ShowSuccessPopup()
    {
        successrText.text = "OTP Verified Successfully!";
        successPanel.SetActive(true);
    }

    IEnumerator DeactivatePopup(GameObject popup, float duration)
    {
        yield return new WaitForSeconds(duration);
        popup.SetActive(false);
    }

    //Edit Button functionality
    public void OnClickEditBtn()
    {
        WelcomePanel.SetActive(false);
        AuthPanel.SetActive(true);
        VerificationPanel.SetActive(false);

        foreach (TMP_InputField inputField in otpInputFields)
        {
            inputField.text = "";
        }
        if (verificationUIManager.keyboard != null && verificationUIManager.keyboard.active)
        {
            verificationUIManager.keyboard.active = false;
            verificationUIManager.keyboard = null;
        }

        verificationUIManager.lastEnteredString = "";
    }


    //Timer functionality
    private void UpdateTimerText()
    {
        int seconds = Mathf.CeilToInt(currentTimer);
        timerText.text = seconds.ToString();
        secText.text = "Sec";
    }
    //Showing resend button when timer is finished
    private void ShowResendButton()
    {
        ResendButton.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        secText.gameObject.SetActive(false);
    }

    //used to resend the OTP
    public void ResendOTP()
    {
        StartResendTimer();
        ResendButton.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
        secText.gameObject.SetActive(true);
    }
    //strat timer when OTP is Resent
    public void StartResendTimer()
    {
        currentTimer = MAX_TIMER_DURATION;
        isTimerRunning = true;
        UpdateTimerText();
    }
}