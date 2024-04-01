using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneController : MonoBehaviour
{
    [SerializeField] private GameObject HomePanel;
    [SerializeField] private GameObject MoreInfoPanel;
    [SerializeField] private GameObject MiniWalletPanel;
    public Button[] buttons;
    void Start()
    {

        HomePanel.SetActive(true);
        MoreInfoPanel.SetActive(false);
        MiniWalletPanel.SetActive(false);

    }



}