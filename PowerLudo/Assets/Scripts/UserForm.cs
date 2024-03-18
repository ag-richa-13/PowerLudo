using UnityEngine;
using TMPro;

public class UserForm : MonoBehaviour
{

    private VerifyOTP verifyOTP;
    [SerializeField] private GameObject LoginPanel;
    [SerializeField] private GameObject FormPanel;
    [SerializeField] private GameObject verificationPanel;
    [SerializeField] private TMP_InputField numberField;
    [SerializeField] private RectTransform cardRectTransform; // Reference to the card's RectTransform
    public string userNumber;
    private bool isKeyboardVisible = false;
    private Vector2 originalCardPosition;

    private void Start()
    {
        // Store the original position of the card
        originalCardPosition = cardRectTransform.anchoredPosition;

        numberField.keyboardType = TouchScreenKeyboardType.NumberPad;

        // Subscribe to input field events
        numberField.onSelect.AddListener(OnInputFieldSelect);
        numberField.onDeselect.AddListener(OnInputFieldDeselect);
    }

    private void OnInputFieldSelect(string text)
    {
        isKeyboardVisible = true;
        AdjustCardPosition();
    }

    private void OnInputFieldDeselect(string text)
    {
        isKeyboardVisible = false;
        AdjustCardPosition();
    }

    private void AdjustCardPosition()
    {
        if (isKeyboardVisible)
        {
            // Get the height of the keyboard
            float keyboardHeight = TouchScreenKeyboard.area.height;

            // Calculate the amount by which to shift the card panel
            float shiftAmount = keyboardHeight + (cardRectTransform.rect.height / 1.5f);

            // Set the position of the card panel
            cardRectTransform.anchoredPosition = new Vector2(cardRectTransform.anchoredPosition.x, originalCardPosition.y + shiftAmount);
        }
        else
        {
            // Reset card panel position when keyboard is hidden
            cardRectTransform.anchoredPosition = originalCardPosition;
        }
    }

    public void OnSubmitButtonClick()
    {
        string phoneNumber = numberField.text;

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            Debug.Log("OTP Sent successfully on your Registered Number.");
            verificationPanel.SetActive(true);
            LoginPanel.SetActive(false);
            FormPanel.SetActive(false);

            userNumber = phoneNumber;

            verifyOTP.numberText.text = userNumber;
        }
        else
        {
            Debug.Log("Please enter a valid mobile number!");
        }
    }
}
