using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserForm : MonoBehaviour
{
    [SerializeField] private GameObject LoginPanel;
    [SerializeField] private GameObject FormPanel;
    [SerializeField] private GameObject verificationPanel;
    [SerializeField] private TMP_InputField numberField;
    [SerializeField] private TMP_Text messageField;

    public void OnSubmitButtonClick()
    {
        string phoneNumber = numberField.text;

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            Debug.Log("Logged In Successfully.");
            verificationPanel.SetActive(true);
            LoginPanel.SetActive(false);
            FormPanel.SetActive(false);
        }
        else
        {
            messageField.text = "Please enter a valid mobile number!";
        }
    }
}
