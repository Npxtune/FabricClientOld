using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugPanel : MonoBehaviour
{
    public GameObject itemUI, objecUI, vaultUI, indUI1, indUI2, FPC, TPC, DebugWindow, rr, skybox, e1, e2, e3, e4, s1, s2, s3, s4;
    public string es1, es2, es3, es4, se1, se2, se3, se4;
    public bool item = false, objec = false, vault = false, ind1 = false, ind2 = false, FPC_if = false, rickr = false, isES;
    public TextMeshProUGUI text1, text2, text3, text4;
    public void ItemUI()
    {
        if (item == false)
        {
            itemUI.SetActive(true);
            item = true;
        }
        else
        {
            itemUI.SetActive(false);
            item = false;
        }
    }
    public void ObjectivesUI()
    {
        if (objec == false)
        {
            objecUI.SetActive(true);
            objec = true;
        }
        else
        {
            objecUI.SetActive(false);
            objec = false;
        }
    }
    public void VaultUI()
    {
        if (vault == false)
        {
            vaultUI.SetActive(true);
            vault = true;
        }
        else
        {
            vaultUI.SetActive(false);
            vault = false;
        }
    }
    public void DMG1()
    {
        if (ind1 == false)
        {
            indUI1.SetActive(true);
            ind1 = true;
        }
        else
        {
            indUI1.SetActive(false);
            ind1 = false;
        }
    }
    public void DMG2()
    {
        if (ind2 == false)
        {
            indUI2.SetActive(true);
            ind2 = true;
        }
        else
        {
            indUI2.SetActive(false);
            ind2 = false;
        }
    }
    public void Fpc()
    {
        if (FPC_if == false)
        {
            TPC.SetActive(false);
            FPC.SetActive(true);
            FPC_if = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            FPC.SetActive(false);
            TPC.SetActive(true);
            FPC_if = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void CloseDebug()
    {
        DebugWindow.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RickAstley()
    {
        if (rickr == false)
        {
            skybox.SetActive(false);
            rr.SetActive(true);
            rickr = true;
        }
        else
        {
            skybox.SetActive(true);
            rr.SetActive(false);
            rickr = false;
        }
    }

    public void UIExample()
    {
        if (isES == false)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            e4.SetActive(true);
            s1.SetActive(false);
            s2.SetActive(false);
            s3.SetActive(false);
            s4.SetActive(false);
            text1.text = es1;
            text2.text = es2;
            text3.text = es3;
            text4.text = es4;
            isES = true;
        }
        else
        {
            e1.SetActive(false);
            e2.SetActive(false);
            e3.SetActive(false);
            e4.SetActive(false);
            s1.SetActive(true);
            s2.SetActive(true);
            s3.SetActive(true);
            s4.SetActive(true);
            text1.text = se1;
            text2.text = se2;
            text3.text = se3;
            text4.text = se4;
            isES = false;
        }
    }
}
