using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Graphics : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_InputField InputField;
    public TMP_Dropdown ResDrop;

    private void Start()
    {
        var input = InputField;
        var se = new TMP_InputField.SubmitEvent();

        input.onEndEdit.AddListener(RefreshRate);

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        ResDrop.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }

        ResDrop.AddOptions(options);
        ResDrop.RefreshShownValue();
    }

    public void Fulscreen(bool isFulscreen)
    {
        Screen.fullScreen = isFulscreen;
    }

    private void RefreshRate(string arg0)
    {
        int fps = int.Parse(arg0);
        Application.targetFrameRate = fps;
        Debug.Log("Changed the Framerate to: " + fps);
    }

    public void Vsync(bool isVsync)
    {
        if (isVsync == true)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    public void GraphicsSettings(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetRes(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
