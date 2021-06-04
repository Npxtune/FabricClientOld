using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public int scene, esc = 0;
    public GameObject page1, options, pauseMenu;
    public bool isSettings;
    public PlayerManager player;

    public void EnableMenu(bool _bool)
    {
        if (_bool == true)
            {
            pauseMenu.SetActive(true);
        }
    }

    public void Continue()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        options.SetActive(false);
        page1.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Settings()
    {
        if (isSettings == false)
        {
            page1.SetActive(false);
            options.SetActive(true);
            isSettings = true;
            esc = 1;
        }
        else
        {
            options.SetActive(false);
            page1.SetActive(true);
            isSettings = false;
            esc = 0;
        }
    }

    public void showPage1()
    {
        options.SetActive(false);
        page1.SetActive(true);
        isSettings = false;
    }

    public void MainMenu()
    {
        Client.instance.Disconnect();
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Client.instance.Disconnect();
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (esc)
            {
                case 0:
                    Continue();
                    break;

                case 1:
                    isSettings = false;
                    Continue();
                    break;
            }
        }
    }
}
