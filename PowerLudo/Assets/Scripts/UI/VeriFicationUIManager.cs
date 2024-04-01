using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerificationUIManager : MonoBehaviour
{
    public VerificationController verificationController;
    [SerializeField] private TMP_InputField[] otpInputFields;
    [SerializeField] private RectTransform cardRectTransform;
    private Vector2 originalCardPosition;
    public TouchScreenKeyboard keyboard;
    private int maxCharacterLimit = 6;
    private int currentInputIndex = 0; // Track the current input index
    public string lastEnteredString = ""; // Track last entered string

    private void Start()
    {
        // Store the original position of the card
        originalCardPosition = cardRectTransform.anchoredPosition;

        foreach (TMP_InputField inputField in otpInputFields)
        {
            // Subscribe to input field events
            inputField.onSelect.AddListener((string text) => OnSelectInputField(inputField)); // Use lambda to capture inputField
        }
    }

    public void OnSelectInputField(TMP_InputField selectedInputField)
    {
        // Open the keyboard with the specified character limit
        keyboard = TouchScreenKeyboard.Open(lastEnteredString, TouchScreenKeyboardType.NumberPad, false, false, false, false, "", maxCharacterLimit);
        // Ensure the caret is at the end of the text
        selectedInputField.MoveTextEnd(false);

        // Update the currentInputIndex only if the selected input field was empty
        currentInputIndex = System.Array.IndexOf(otpInputFields, selectedInputField);

        // Reset last entered string to empty when input field is selected
        lastEnteredString = "";

        //Hide Mobile Input Screen
        TouchScreenKeyboard.hideInput = true;
    }


    private void Update()
    {
        if (keyboard != null && keyboard.active)
        {
            AdjustCardPosition();
            OnKeyboardClick();
        }
        else
        {
            ResetCardPosition();
        }
    }

    private void AdjustCardPosition()
    {
        if (keyboard != null)
        {
            // Get the height of the keyboard
            float keyboardHeight = TouchScreenKeyboard.area.height;

            // Calculate the amount by which to shift the card panel
            float shiftAmount = keyboardHeight + (cardRectTransform.rect.height / 1.5f);

            // Set the position of the card panel
            cardRectTransform.anchoredPosition = new Vector2(cardRectTransform.anchoredPosition.x, originalCardPosition.y + shiftAmount);
        }
    }

    private void ResetCardPosition()
    {
        cardRectTransform.anchoredPosition = originalCardPosition;
    }

    public void OnKeyboardClick()
    {
        string keyboardInput = keyboard.text;

        for (int i = 0; i < otpInputFields.Length; i++)
        {
            if (i < keyboardInput.Length)
            {
                // Update corresponding input field with character from keyboard input
                otpInputFields[i].text = keyboardInput[i].ToString();
            }
            else
            {
                // Clear remaining input fields if characters are less than max limit
                otpInputFields[i].text = "";
            }
        }

        // Move to the next input field after filling the current one
        if (keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            verificationController.OnVerifyButtonClick();
        }

        // Update last entered string
        lastEnteredString = keyboardInput;
    }
}
