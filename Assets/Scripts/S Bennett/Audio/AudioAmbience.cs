using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbience : MonoBehaviour
{
    private AudioController audioController;

    public bool canPlayAmbience;
    private bool ambiencePlaying = false;
    [SerializeField] private int ambienceClipNumber;

    private void Start() 
    {
        audioController = GetComponent<AudioController>();   
    }

    private void Update()
    {
        HandleAmbience();
    }

    private void HandleAmbience()
    {
        if (canPlayAmbience && !ambiencePlaying)
        {
            PlayRandomAmbience();
            ambiencePlaying = true;
        } 
        else if (!canPlayAmbience && ambiencePlaying)
        {
            StopAmbience();
            ambiencePlaying = false;
        }
    }

    private void PlayRandomAmbience()
    {
        if (ambiencePlaying) return;

        int randomAudioClip = Random.Range(0, ambienceClipNumber);
        Debug.Log(randomAudioClip);

        switch(randomAudioClip)
        {
            case 0:
                audioController.PlayAudioClip("AmbienceTrack1", AudioMixerChannels.Music);
                break;
            case 1:
                audioController.PlayAudioClip("AmbienceTrack2", AudioMixerChannels.Music);
                break;
            case 2:
                audioController.PlayAudioClip("AmbienceTrack3", AudioMixerChannels.Music);
                break;
            default:
                break;
        }
    }

    public void StopAmbience()
    {
        audioController.StopMusic();
    }
}
