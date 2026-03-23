using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public bool isOpened = false;
    public bool isSettingsOpened = false;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject menu;

    private Resolution[] customResolutions;
    private InputSystem_Actions inputAction;

    private void Awake()
    {
        inputAction = new InputSystem_Actions();
    }

    private void Start()
    {
        DefineCustomResolutions();
        LoadSettings();
    }

    private void DefineCustomResolutions()
    {
        customResolutions = new Resolution[]
        {
            CreateResolution(1920, 1080),
            CreateResolution(1600, 900),
            CreateResolution(1366, 768),
            CreateResolution(1280, 720),
            CreateResolution(1024, 768)
        };

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < customResolutions.Length; i++)
        {
            options.Add(customResolutions[i].width + " x " + customResolutions[i].height);

            if (customResolutions[i].width == Screen.width && customResolutions[i].height == Screen.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private Resolution CreateResolution(int width, int height)
    {
        Resolution res = new Resolution();
        res.width = width;
        res.height = height;
        return res;
    }

    private void LoadSettings()
    {
        if (volumeSlider != null)
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0);
        if (fullscreenToggle != null)
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        ApplyVolume(volumeSlider.value);
        ApplyFullscreen(fullscreenToggle.isOn);
        ApplyResolution(resolutionDropdown.value);
    }

    private void OnEnable()
    {
        inputAction.Player.OpenMenu.performed += OnPausePerformed;
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.OpenMenu.performed -= OnPausePerformed;
        inputAction.Player.Disable();
    }

    private void OnPausePerformed(InputAction.CallbackContext context)
    {
        if (GameManager.instance != null && GameManager.instance.sceneIndex == 1)
            ShowHideMenu();
    }

    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        menu.SetActive(isOpened);
    }

    public void ShowSettingMenu()
    {
        isSettingsOpened = !isSettingsOpened;
        settingsMenu.SetActive(isSettingsOpened);
        menu.SetActive(!isSettingsOpened);
    }

    public void ChangeResolution(int index)
    {
        ApplyResolution(index);
        PlayerPrefs.SetInt("Resolution", index);
    }

    private void ApplyResolution(int index)
    {
        Resolution res = customResolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void ChangeFullscreenMode(bool isFullscreen)
    {
        ApplyFullscreen(isFullscreen);
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }

    private void ApplyFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ChangeVolume(float value)
    {
        ApplyVolume(value);
        PlayerPrefs.SetFloat("Volume", value);
    }

    private void ApplyVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
    }

    public void GoToMain()
    {
        GameManager.instance.sceneIndex = 0;
        SceneManager.LoadScene(GameManager.instance.sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        GameManager.instance.sceneIndex = 1;
        SceneManager.LoadScene(GameManager.instance.sceneIndex);
    }
    public void ApplySettings()
    {
        ApplyFullscreen(fullscreenToggle.isOn);
        ApplyResolution(resolutionDropdown.value);
        ApplyVolume(volumeSlider.value);
    }
}