using UnityEngine;

public class AndroidBackButton : MonoBehaviour
{
    public GameObject RegistrationPanel;
    public GameObject formPanel;

    void Update()
    {
        // Check if the back button (Escape key) is pressed on Android
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the form panel is active, switch to the login panel
            if (formPanel.activeSelf)
            {
                formPanel.SetActive(false);
                RegistrationPanel.SetActive(true);
            }
            else
            {
                // If the login panel is active, quit the application
                Application.Quit();
            }
        }
    }
}
