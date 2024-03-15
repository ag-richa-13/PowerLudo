using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private Slider LoadBar;
    public int NextSceneIndex = 1;
    public float fillTime = 3f; // Total time to fill the progress bar
    private float timer = 0f;

    public void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Calculate progress
        float progress = timer / fillTime;

        // Update progress bar
        LoadBar.value = progress;

        // Check if progress is complete
        if (progress >= 1f)
        {
            // Load next scene
            SceneManager.LoadScene(NextSceneIndex);
        }
    }
}
