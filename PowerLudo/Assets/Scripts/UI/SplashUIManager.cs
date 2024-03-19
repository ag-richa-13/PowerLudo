using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashUIManager : MonoBehaviour
{
    [SerializeField] private Slider LoadBar;
    private int NextSceneIndex = 1;
    float fillTime = 3f;
    private float timer = 0f;

    public void Update()
    {

        timer += Time.deltaTime;


        float progress = timer / fillTime;


        LoadBar.value = progress;


        if (progress >= 1f)
        {

            SceneManager.LoadScene(NextSceneIndex);
        }
    }
}
