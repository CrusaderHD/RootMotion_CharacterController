using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class MenuVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    //Manage Audio through a slider on a logorithmic scale. 
    public void SetLevel()
    {
        float sliderValue = slider.value;
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    
}
