using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FR : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fr;
    float timeElapsed = 1;
    int interval = 1;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        while (timeElapsed >= interval)
        {
            timeElapsed -= interval;
            float fps = 1 / Time.unscaledDeltaTime;

            fr.text = fps.ToString("F0") + " FPS";
        }
    }
}
