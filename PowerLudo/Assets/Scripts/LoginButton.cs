using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    [SerializeField] private GameObject LoginPanel; // Corrected variable name
    [SerializeField] private GameObject FormPanel;

    public void OnLoginButtonClick(){
        FormPanel.SetActive(true);
        LoginPanel.SetActive(false); // Corrected variable name
    }
}
