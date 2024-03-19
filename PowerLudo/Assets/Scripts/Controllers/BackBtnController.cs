using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBtnController : MonoBehaviour
{
    [SerializeField] private GameObject WelcomePanel;
    [SerializeField] private GameObject AuthPanel;
    [SerializeField] private GameObject VerificationPanel;

    void Update()
    {
        // Check if the back button (Escape key) is pressed on Android
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check karein agar user WelcomePanel mein hai
            if (WelcomePanel.activeSelf)
            {
                // Unity se bahar jaane ke liye Application.Quit() use karein
                Application.Quit();
            }
            // Check karein agar user AuthPanel se back karna chahta hai
            else if (AuthPanel.activeSelf)
            {
                // AuthPanel ko disable karein aur WelcomePanel ko enable karein
                AuthPanel.SetActive(false);
                WelcomePanel.SetActive(true);
            }
            // Check karein agar user VerificationPanel se back karna chahta hai
            else if (VerificationPanel.activeSelf)
            {
                // VerificationPanel ko disable karein aur AuthPanel ko enable karein
                VerificationPanel.SetActive(false);
                AuthPanel.SetActive(true);
            }
        }
    }
}
