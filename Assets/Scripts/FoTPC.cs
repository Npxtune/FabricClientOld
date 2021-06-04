using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoTPC : MonoBehaviour
{
    public GameObject TPC, FPC, UI;
    public TP_Movement tp;
    public FP_Movement fp;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ThirdPerson()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UI.SetActive(false);
        FPC.SetActive(false);
        TPC.SetActive(true);
        tp.isF3 = false;
        Debug.Log("Third Person");
    }

    public void FirstPerson()
    {
        fp.isUI = false;
        tp.isF3 = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UI.SetActive(false);
        TPC.SetActive(false);
        FPC.SetActive(true);
        GameObject.Find("Camera").SendMessage("enableUI", false);
        Debug.Log("First Person");
    }
}
