using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    public Slider masterVolumeSlider;
    public Slider menuVolumeSlider;
    public Slider inGameVolumeSlider;

    Resolution[] resolutionsArray;
    List<Resolution> resolutions;

    static Resolution pickedResolution = new Resolution();

    static float pickedMasterVolume = 1;
    static float pickedMenuVolume = 1;
    static float pickedInGameVolume = 1;


    void Start()
    {
        //array to list
        resolutionsArray = Screen.resolutions;
        resolutions = resolutionsArray.OfType<Resolution>().ToList();
        /*
        for (int i = 0; i < resolutionsArray.Length; i++)
        {
            resolutions.Add(resolutionsArray[i]);
        }
        */
        resolutionsArray = null;

        //fill dropdown
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (options.Contains(option))   //eliminate duplicates caused by refreshRate
            {
                resolutions.Remove(resolutions[i]);
                i--;
                continue;
            }

            options.Add(option);
            if (pickedResolution.width == 0)    //default settings
            {
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
            else    //settings set before
            {
                if (resolutions[i].width == pickedResolution.width &&
                    resolutions[i].height == pickedResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }
        }

        //update elements
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        fullscreenToggle.isOn = Screen.fullScreen;

        masterVolumeSlider.value = pickedMasterVolume;
        menuVolumeSlider.value = pickedMenuVolume;
        inGameVolumeSlider.value = pickedInGameVolume;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(AudioVolumes.Master, Mathf.Log10(volume) * 20); //min. 0.0001 - max. 1
        pickedMasterVolume = masterVolumeSlider.value;
    }

    public void SetMenuVolume(float volume)
    {
        audioMixer.SetFloat(AudioVolumes.MainMenu, Mathf.Log10(volume) * 20); //min. 0.0001 - max. 1
        pickedMenuVolume = menuVolumeSlider.value;
    }

    public void SetInGameVolume(float volume)
    {
        audioMixer.SetFloat(AudioVolumes.InGame, Mathf.Log10(volume) * 20); //min. 0.0001 - max. 1
        pickedInGameVolume = inGameVolumeSlider.value;
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
        pickedResolution = resolutions[resolutionIndex];
    }
}
