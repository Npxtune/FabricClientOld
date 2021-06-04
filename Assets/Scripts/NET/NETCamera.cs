using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NETCamera : MonoBehaviour
{
    public float mouseSens = 100f;
    public PlayerManager player;
    private float clampAngle = 85f;
    public bool isUI;
    private float verticalRotation, horizontalRotation;
    public NETController controller;


    // Start is called before the first frame update
    void Start()
    {
        verticalRotation = transform.localEulerAngles.x;
        horizontalRotation = player.transform.eulerAngles.y;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Continue()
    {
        controller.isUI = false;
        isUI = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUI == false)
        {
            Look();
            // Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isUI == false)
            {
                controller.isUI = true;
                isUI = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                GameObject.Find("UImng").SendMessage("EnableMenu", true);
            }
            else
            {
                controller.isUI = false;
                isUI = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    private void Look()
    {
        float _mouseVertical = Input.GetAxis("Mouse Y");
        float _mouseHorizontal = Input.GetAxis("Mouse X");

        verticalRotation -= _mouseVertical * mouseSens * Time.deltaTime;
        horizontalRotation += _mouseHorizontal * mouseSens * Time.deltaTime;

        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        player.transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }

    void enableUI(bool _bool)
    {
        isUI = _bool;
    }
}
