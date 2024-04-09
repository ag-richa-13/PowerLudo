using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public HomeSceneController homeSceneController;
    [SerializeField] private GameObject HomePanel;
    [SerializeField] private GameObject MoreInfoPanel;
    [SerializeField] private GameObject WalletPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (HomePanel.activeSelf)
            {

                Application.Quit();
            }

            else if (MoreInfoPanel.activeSelf)
            {

                homeSceneController.OnClickHomeButton();
            }
            else if (WalletPanel.activeSelf)
            {
                homeSceneController.OnClickHomeButton();
            }
        }
    }
}