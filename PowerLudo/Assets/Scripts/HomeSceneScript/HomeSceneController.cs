using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneController : MonoBehaviour
{
    [SerializeField] private GameObject HomePanel;
    [SerializeField] private GameObject MoreInfoPanel;
    [SerializeField] private GameObject MiniWalletPanel;
    [SerializeField] private GameObject WalletPanel;
    public Button[] buttons;
    void Start()
    {

        HomePanel.SetActive(true);
        MoreInfoPanel.SetActive(false);
        MiniWalletPanel.SetActive(false);


        buttons[3].gameObject.SetActive(true);
        buttons[0].gameObject.SetActive(true);
        buttons[4].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(false);
        buttons[5].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
    }
    public void OnClickMoreButton()
    {
        HomePanel.SetActive(false);
        MoreInfoPanel.SetActive(true);
        MiniWalletPanel.SetActive(false);
        WalletPanel.SetActive(false);


        buttons[3].gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(true);
        buttons[4].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[5].gameObject.SetActive(true);
        buttons[2].gameObject.SetActive(true);
    }


    public void OnClickHomeButton()
    {
        HomePanel.SetActive(true);
        MoreInfoPanel.SetActive(false);
        MiniWalletPanel.SetActive(false);
        WalletPanel.SetActive(false);


        buttons[3].gameObject.SetActive(true);
        buttons[0].gameObject.SetActive(true);
        buttons[4].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(false);
        buttons[5].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);

    }

    public void OnClickWalletButton()
    {
        HomePanel.SetActive(false);
        MoreInfoPanel.SetActive(false);
        MiniWalletPanel.SetActive(false);
        WalletPanel.SetActive(true);

        buttons[3].gameObject.SetActive(false);
        buttons[0].gameObject.SetActive(false);
        buttons[4].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(true);
        buttons[5].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(true);

    }
    public void OnclickMiniWalletButton()
    {
        if (HomePanel.activeSelf)
        {
            MoreInfoPanel.SetActive(false);
            WalletPanel.SetActive(false);
            MiniWalletPanel.SetActive(true);

            buttons[3].gameObject.SetActive(true);
            buttons[0].gameObject.SetActive(true);
            buttons[4].gameObject.SetActive(true);
            buttons[1].gameObject.SetActive(false);
            buttons[5].gameObject.SetActive(false);
            buttons[2].gameObject.SetActive(false);
        }
        else if (MoreInfoPanel.activeSelf)
        {
            HomePanel.SetActive(false);
            WalletPanel.SetActive(false);
            MiniWalletPanel.SetActive(true);

            buttons[3].gameObject.SetActive(false);
            buttons[0].gameObject.SetActive(true);
            buttons[4].gameObject.SetActive(false);
            buttons[1].gameObject.SetActive(false);
            buttons[5].gameObject.SetActive(true);
            buttons[2].gameObject.SetActive(true);
        }

        else if (WalletPanel.activeSelf)
        {
            HomePanel.SetActive(false);
            MoreInfoPanel.SetActive(false);
            MiniWalletPanel.SetActive(true);

        }
    }

    public void OnClickDropdown()
    {
        MiniWalletPanel.SetActive(false);
    }
}