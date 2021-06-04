using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    // Methods to send audio info to the Audio Manager

    public void SetVolume(float volume)
    {
        GameObject.Find("AudioManager").SendMessage("changeVolume", volume);
    }

    public void MuteVolume(bool mute)
    {
        GameObject.Find("AudioManager").SendMessage("muteVolume", mute);
    }

    public void FocusAllowed(bool _bool)
    {
        GameObject.Find("AudioManager").SendMessage("ifFallowed", _bool);
    }
}
