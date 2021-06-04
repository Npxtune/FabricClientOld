using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FPS_Display : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fpsText;
    float timeElapsed = 1;
    int interval = 1;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        while (timeElapsed >= interval)
        {
            timeElapsed -= interval;
            float fps = 1 / Time.unscaledDeltaTime;

            fpsText.text = fps.ToString("F0") + " FPS";
        }
    }
}
