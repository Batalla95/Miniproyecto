using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettingsManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;
    public Slider masterSlider, musicSlider, effectsSlider;

    [Header("Graphics")]
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    const string MixerOpciones_Master = "Master";
    const string MixerOpciones_Music = "Music";
    const string MixerOpciones_Effects = "Effects";

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);

        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);

        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }
    private void Start()
    {
        
        masterSlider.value = PlayerPrefs.GetFloat("Master", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("Music", 1f);
        effectsSlider.value = PlayerPrefs.GetFloat("Effects", 1f);

       
        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetEffectsVolume(effectsSlider.value);

        
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionDropdown.options.Add(new TMPro.TMP_Dropdown.OptionData(resolutions[i].width + "x" + resolutions[i].height));
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex", currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();

        
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        fullscreenToggle.isOn = isFullscreen;
        Screen.fullScreen = isFullscreen;
    }

    
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat("Master", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat("Music", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("Effects", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat("Effects", volume);
    }

    
    public void SetResolution(int resolutionIndex)
    {
        if (resolutionIndex < 0 || resolutionIndex >= resolutions.Length) return;
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
    }

    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }
}