using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
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

                MoreInfoPanel.SetActive(false);
                HomePanel.SetActive(true);
                WalletPanel.SetActive(false);
            }
            else if (WalletPanel.activeSelf)
            {
                MoreInfoPanel.SetActive(false);
                HomePanel.SetActive(true);
                WalletPanel.SetActive(false);
            }
        }
    }
}