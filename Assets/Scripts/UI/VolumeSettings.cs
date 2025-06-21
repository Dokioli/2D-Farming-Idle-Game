using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider musicSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicSlider();
            SetVolumeSlider();
        }
    }

    public void SetVolumeSlider()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("SFXParameter", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetMusicSlider()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("MusicParameter", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        SetMusicSlider();
        SetVolumeSlider();
    }
}
