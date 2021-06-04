using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vault : MonoBehaviour
{
    public GameObject vault, vaultUI;
    public CharacterController player;
    public int xVault, zVault;
    public bool vaultMesh = false, showUI = false, isVaulting = false, spaceHold = false;      

    //TODO: Rework for Multiplayer!!!

    void OnTriggerEnter(Collider other)
    {
        if (showUI == true)
        {
            vaultUI.SetActive(true);
        }
        if (vaultMesh == true)
        {
            // For debugging
            Debug.Log("Enabled Vault mesh collider");
            vault.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (isVaulting == false && spaceHold == false)
        { 
            if (Input.GetButton("Jump") && vaultMesh == false)
            {
                isVaulting = true;
                spaceHold = true;
                vault.SetActive(false);
                Debug.Log("Pressed Spacebar");
                Debug.Log("Disabling Vault mesh collider");
                Vector3 mVault = new Vector3(xVault, 0f, zVault) * Time.deltaTime;
                player.Move(mVault);
                Debug.Log("Player Vaulted the Window");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (showUI == true)
        {
            vaultUI.SetActive(false);
        }
        isVaulting = false;
    }
}