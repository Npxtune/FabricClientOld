using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImng : MonoBehaviour
{
    public GameObject pauseMenu;

    public void EnableMenu(bool _bool)
    {
        if (_bool == true)
        {
            pauseMenu.SetActive(true);
        }
    }
}