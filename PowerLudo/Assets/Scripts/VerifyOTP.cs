using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VerifyOTP : MonoBehaviour
{

    [SerializeField] private GameObject FormPanel;
    [SerializeField] private GameObject verificationPanel;
    [SerializeField] private TMP_InputField[] otpInputFields;
    public TMP_Text numberText;
    [SerializeField] private RectTransform cardRectTransform;
    private int NextSceneIndex = 2;

    private const int OTP_LENGTH = 6; // Length of OTP
    private bool isKeyboardVisible = false;
    private Vector2 originalCardPosition;
    private void Start()
    {
        // Store the original position of the card
        originalCardPosition = cardRectTransform.anchoredPosition;

        // Set keyboard type for each input field in the array
        foreach (TMP_InputField inputField in otpInputFields)
        {
            inputField.keyboardType = TouchScreenKeyboardType.NumberPad;

            // Subscribe to input field events
            inputField.onSelect.AddListener(OnInputFieldSelect);
            inputField.onDeselect.AddListener(OnInputFieldDeselect);
        }
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
            }
        }
        else
        {
            Debug.Log("Please enter a valid OTP!");
        }
    }

    public void OnClickEditBtn()
    {
        FormPanel.SetActive(true);
        verificationPanel.SetActive(false);
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
}
