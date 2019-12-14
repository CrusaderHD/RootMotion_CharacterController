using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Create an array of sounds that can be added-removed and control sound features. 
    public SoundController[] soundController;

    //Create an option for Looping Sounds
    public bool loopAudio;

    public void Awake()
    {
        foreach (SoundController s_Controller in soundController)
        {
            s_Controller.audioSource = gameObject.AddComponent<AudioSource>();
            s_Controller.audioSource.clip = s_Controller.a_Clip;
            //Set volume and pitch
            s_Controller.audioSource.volume = s_Controller.volumeController;
            s_Controller.audioSource.pitch = s_Controller.pitchController;
            s_Controller.audioSource.loop = s_Controller.loopAudio;
        }
    }

    //Play Audio
    public void PlayAudio(string name)
    {
        SoundController sc = Array.Find(soundController, sound => sound.audioName == name);
        sc.audioSource.Play();
    }

}
