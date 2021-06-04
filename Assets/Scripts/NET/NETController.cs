using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NETController : MonoBehaviour
{
    public bool isUI;

    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        if (isUI == false)
        {
            bool[] _inputs = new bool[]
            {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D)
            };
            ClientSend.PlayerMovement(_inputs);
        }
        else
        {
            bool[] _inputs = new bool[]
            {
                false,
                false,
                false,
                false
            };
            ClientSend.PlayerMovement(_inputs);
        }
        
    }
}
