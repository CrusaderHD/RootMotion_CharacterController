using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundController
{
    //Name of Audio Clip
    public string audioName;

    //Reference to Audio Clips.
    public AudioClip a_Clip;

    //Volume and Pitch Controller.
    [Range(0f, 1f)]
    public float volumeController;
    [Range(.1f, 3f)]
    public float pitchController;

    //Create a variable to store the audio source. Create public to be used elsewhere, but Hide in the inspector.
    [HideInInspector]
    public AudioSource audioSource;

    public bool loopAudio;
}
