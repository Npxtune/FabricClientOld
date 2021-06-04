using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    public int scene, esc = 0, netScene = 3;
    public GameObject widgetQuit, page1, page2, options;
    public TMP_InputField InputField;

    public void Start()
    {
        var input = InputField;
        var se = new TMP_InputField.SubmitEvent();
        input.onEndEdit.AddListener(getNetScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void getNetScene(string _string)
    {
        if (_string == "")
        {
            return;
        }
        netScene = Int16.Parse(_string);
        Debug.Log($"Switched to NET scene {netScene}");
    }

    public void LoadNET()
    {
        SceneManager.LoadScene(netScene);
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void showPage1()
    {
        options.SetActive(false);
        page2.SetActive(false);
        page1.SetActive(true);
        esc = 0;
    }

    public void showPage2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        esc = 1;
    }

    public void showSettings()
    {
        page1.SetActive(false);
        options.SetActive(true);
        esc = 2;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (esc)
            {
                case 0:
                    break;

                case 1:
                    page2.SetActive(false);
                    page1.SetActive(true);
                    esc = 0;
                    break;

                case 2:
                    options.SetActive(false);
                    page1.SetActive(true);
                    esc = 0;
                    break;
            }
        }
    }
}