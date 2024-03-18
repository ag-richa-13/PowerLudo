using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VerifyOTP : MonoBehaviour
{
    private UserForm userForm;
    [SerializeField] private GameObject FormPanel;
    [SerializeField] private GameObject verificationPanel;
    [SerializeField] private TMP_InputField[] otpInputFields;
    [SerializeField] private TMP_Text text;
    private int NextSceneIndex = 2;

    private const int OTP_LENGTH = 6; // Length of OTP

    private void Start()
    {
        text.text = $"{userForm.userNumber}";
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
                SceneManager.LoadScene(NextSceneIndex);
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
}
