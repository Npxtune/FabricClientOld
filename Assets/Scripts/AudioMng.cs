using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMng : MonoBehaviour
{
    public AudioMixer audiomixer;
    float musicVol;
    bool isMuted, focusAllowed = true;

    // Enables / Disables Mute Focus
    void ifFallowed(bool _bool)
    {
        if (_bool == false)
        {
            focusAllowed = false;
            Debug.Log("Mute focus was disabled");
        }
        else
        {
            focusAllowed = true;
            Debug.Log("Mute focus was enabled");
        }
    }

    // Changes the volume from -20 -> 5
    void changeVolume(float _float)
    {
        if (isMuted == false)
        {
            audiomixer.SetFloat("volume", _float);
            musicVol = _float;
            Debug.Log($"Changed Volume to: {_float}");
        }
        else
        {
            musicVol = _float;
        }

    }
    
    // Mutes the volume (sets it to -80)
    void muteVolume(bool _bool)
    {
        if (_bool == true)
        {
            audiomixer.SetFloat("volume", -80);
            isMuted = true;
            Debug.Log($"Muted the Volume");
        }
        else
        {
            audiomixer.SetFloat("volume", musicVol);
            isMuted = false;
            Debug.Log($"Unmuted Volume to: {musicVol}");
        }

    }

    // Checks if Applications is unfocused and mutes it accordingly
    public void OnApplicationFocus(bool focus = true)
    {
        if (focusAllowed == true)
        {
            if (isMuted == false)
            {
                switch (focus)
                {
                    case false:
                        audiomixer.SetFloat("volume", -80);
                        Debug.Log($"Application unfocused, muted the Volume");
                        break;

                    case true:
                        audiomixer.SetFloat("volume", musicVol);
                        Debug.Log($"Application focused, unmuted Volume to: {musicVol}");
                        break;
                }
            }
        } 
    }
}
