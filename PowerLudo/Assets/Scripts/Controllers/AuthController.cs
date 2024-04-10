using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Networking;

public class AuthController : MonoBehaviour
{
    public AuthUIManager authUIManager;
    public VerificationUIManager verificationUIManager;
    public VerificationController verificationController;
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private GameObject AuthPanel;
    [SerializeField] private GameObject VerificationPanel;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private GameObject successPanel;

    //submit button
    [SerializeField] private Button SubmitButton;
    public Sprite originalColor;
    public Sprite transparentColor;
    public TMP_InputField numberField;

    public int numberLimit = 10;

    public string userNumber;

    //Error and Success pop up
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private TMP_Text successText;

    [SerializeField] private float popupDuration = 3f; // Duration for error/success pop-up

    private Coroutine popupCoroutine;

    public void Start()
    {
        WelcomePanel.SetActive(true);
        AuthPanel.SetActive(false);
        VerificationPanel.SetActive(false);
        errorPanel.SetActive(false);
        successPanel.SetActive(false);

        SubmitButton.image.sprite = transparentColor;
        numberField.onValueChanged.AddListener(OnValueChanged);
        // numberField.onSelect.AddListener(OnSelect);
    }

    private void OnValueChanged(string mobileNumber)
    {
        if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length == numberLimit)
        {
            SubmitButton.image.sprite = originalColor;
        }
        else
        {
            SubmitButton.image.sprite = transparentColor;
        }
    }

    public void OnSubmitButtonClick()
    {
        string phoneNumber = numberField.text;

        if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == numberLimit)
        {
            Debug.Log("OTP Sent successfully on your Registered Number.");
            VerificationPanel.SetActive(true);
            WelcomePanel.SetActive(false);
            AuthPanel.SetActive(false);

            userNumber = phoneNumber;
            verificationController.numberText.text = phoneNumber;
            verificationController.ResendOTP();
            StartCoroutine(SendPhoneNumber(phoneNumber));
            ShowSuccessPopup("OTP Sent successfully!");
        }
        else
        {
            Debug.Log("Please enter a valid mobile number!");
            ShowErrorPopup("Please enter a valid mobile number!");
        }

        foreach (TMP_InputField inputField in verificationController.otpInputFields)
        {
            inputField.text = "";
        }

        verificationUIManager.lastEnteredString = "";
    }

    IEnumerator SendPhoneNumber(string mobile)
    {
        string url = "http://192.168.10.73:3000/v1/auth/login";
        WWWForm form = new WWWForm();
        form.AddField("mobile", mobile);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    private void ShowErrorPopup(string errorMessage)
    {
        errorText.text = errorMessage;
        errorPanel.SetActive(true);
        if (popupCoroutine != null)
            StopCoroutine(popupCoroutine);
        popupCoroutine = StartCoroutine(HidePopup(errorPanel));
    }

    private void ShowSuccessPopup(string successMessage)
    {
        successText.text = successMessage;
        successPanel.SetActive(true);
        if (popupCoroutine != null)
            StopCoroutine(popupCoroutine);
        popupCoroutine = StartCoroutine(HidePopup(successPanel));
    }

    private IEnumerator HidePopup(GameObject popupPanel)
    {
        yield return new WaitForSeconds(popupDuration);
        popupPanel.SetActive(false);
    }

    public void OnClickTandC()
    {
        Application.OpenURL("http://unity3d.com/");
    }
}
