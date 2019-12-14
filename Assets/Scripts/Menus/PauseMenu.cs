using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    public Dropdown graphicsDropdown;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        //Set default resolution.
        int currentResolutionIndex = 0;

        //Loop through different screen resolutions.
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        //Add Resolutions options to the dropdown.
        resolutionDropdown.AddOptions(options);
        //SetValues.
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        graphicsDropdown.value = PlayerPrefs.GetInt("GraphicSettings", 1);
    }

    // Update is called once per frame
    void Update()
    {
        OpenPause();
    }

    void OpenPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        //Open Pause menu and freeze in game time.
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetQuality()
    {
        int settingsValue = graphicsDropdown.value;
        PlayerPrefs.SetInt("GraphicSettings", settingsValue);
        //QualitySettings.SetQualityLevel(qualityIndex);
    }


    public void QuitGame()
    {
        //Since this wont happen within the Unity Editor. Adding a Debug Log method.
        Debug.Log("Quitting Game.");
        Application.Quit();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
