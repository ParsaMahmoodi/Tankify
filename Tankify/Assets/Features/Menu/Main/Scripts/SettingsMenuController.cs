using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Features.Menu.Main.Scripts
{
    public class SettingsMenuController : MonoBehaviour
    {

        [SerializeField]
        private AudioMixer _audioMixer;
        
        [SerializeField]
        private Dropdown _resolutionDropdown;

        [SerializeField]
        private MainMenuController _mainMenuController;

        private Resolution[] _resolutions;
        
        private void Start()
        {
            _resolutions = Screen.resolutions;
            
            _resolutionDropdown.ClearOptions();

            List<string> resolutionOptions = new List<string>();

            int currentResolutionIndex = 0;
            
            for (int index = 0; index < _resolutions.Length; index++)
            {
                string option = _resolutions[index].width + " x " + _resolutions[index].height;
                resolutionOptions.Add(option);

                if (_resolutions[index].width == Screen.currentResolution.width && _resolutions[index].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = index;
                }

            }

            _resolutionDropdown.AddOptions(resolutionOptions);

            _resolutionDropdown.value = currentResolutionIndex;
            _resolutionDropdown.RefreshShownValue();
        }

        public void SetVolume (float volume)
        {
            _audioMixer.SetFloat("volume", volume);
        }
        
        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void ResetProgress()
        {
            _mainMenuController.ResetProgressData();
        }

        public void SetupSettingsMenu()
        {
            gameObject.SetActive(true);
        }

        public void CloseSettingsMenu()
        {
            gameObject.SetActive(false);
        }
    
    }
}
