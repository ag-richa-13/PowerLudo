using UnityEngine;
using TMPro;

public class UserForm : MonoBehaviour
{
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject formPanel;
    [SerializeField] private GameObject verificationPanel;
    [SerializeField] private RectTransform cardRectTransform; // Reference to the card's RectTransform

    private TouchScreenKeyboard keyboard;

    private Vector2 originalCardPosition;

    private void Start()
    {
        // Store the original position of the card
        originalCardPosition = cardRectTransform.anchoredPosition;

        // Set the keyboard type to NumberPad
        TouchScreenKeyboard.hideInput = true;
    }

    private void Update()
    {
        // Check if the keyboard is visible
        if (keyboard != null && !keyboard.active)
        {
            // Reset card panel position when keyboard is hidden
            cardRectTransform.anchoredPosition = originalCardPosition;
        }
    }

    public void OnSubmitButtonClick()
    {
        // Show verification panel
        verificationPanel.SetActive(true);
        loginPanel.SetActive(false);
        formPanel.SetActive(false);
    }

    public void OnInputFieldSelect()
    {
        // Show the keyboard when input field is selected
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
    }
}
