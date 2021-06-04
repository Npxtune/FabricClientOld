using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDLmng : MonoBehaviour
{
    public GameObject audioManager;

    // Adds the Audio Manager to not be destroyed
    void Start()
    {
        DontDestroyOnLoad(audioManager);
    }
}
