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
                // MoreInfoPanel.SetActive(false);
                // HomePanel.SetActive(true);
                // WalletPanel.SetActive(false);

                // buttons[3].gameObject.SetActive(true);
                // buttons[0].gameObject.SetActive(true);
                // buttons[4].gameObject.SetActive(true);
                // buttons[1].gameObject.SetActive(false);
                // buttons[5].gameObject.SetActive(false);
                // buttons[2].gameObject.SetActive(false);
            }
            else if (WalletPanel.activeSelf)
            {
                homeSceneController.OnClickHomeButton();
                // MoreInfoPanel.SetActive(false);
                // HomePanel.SetActive(true);
                // WalletPanel.SetActive(false);
            }
        }
    }
}