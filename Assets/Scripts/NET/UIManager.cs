using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject UI, Camera;
    public TMP_InputField usernameField, IPField;

    private void Start()
    {
        var input = IPField;
        var se = new TMP_InputField.SubmitEvent();

        input.onEndEdit.AddListener(EnterIP);
    }

    private void EnterIP(string arg0)
    {
        if (arg0 == "")
        {
            Debug.Log($"Could not change the IP due to an empty argument.");
            return;
        }
        else
        {
            GameObject.Find("ClientManager").SendMessage("ReceiveIP", arg0);
            Debug.Log($"Target IP: {arg0}");
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying objects!");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        Camera.SetActive(false);
        UI.SetActive(false);
        usernameField.interactable = false;
        Client.instance.ConnectToServer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}
