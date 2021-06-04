using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    [SerializeField]
    private TMP_Text usernameFront, usernameBack;

    public void Start()
    {
        usernameFront.text = username;
        usernameBack.text = username;
    }
}