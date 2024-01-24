#if UNITY_WEBGL
#pragma warning disable
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardScript : MonoBehaviour
{
    private int upCount = 0;
    public Toggle isClavierscreen;
    public InputField TextField;
    public GameObject Kb, AzertLayoutSml, AzertLayoutBig, SymbLayout,TexteActiver;
    public Toggle isClavierscreenClock;

    public void alphabetFunction(string alphabet)
    {
      
        if (AzertLayoutBig.activeSelf && !isClavierscreenClock.isOn)
        {
            ShowLayout(AzertLayoutSml);
        }
        upCount = 0;
        TextField.text=TextField.text + alphabet;

    }
    public void upCase()
    {
        if (isClavierscreenClock.isOn)
        {
            isClavierscreenClock.isOn = false;
            upCount = 0;
        }
        else
        {
            upCount++;
            if (upCount > 1)
            {
                isClavierscreenClock.isOn = true;
                upCount = 0;
            }
        }
       
    }
    public void BackSpace()
    {

        if(TextField.text.Length>0) TextField.text= TextField.text.Remove(TextField.text.Length-1);

    }
    public void AzertO()
    {
        if (isClavierscreen.isOn)
        {
             Kb.SetActive(true);
        }
       
    }
    public void AzertC()
    {

        Kb.SetActive(false);
    }

    public void changecaplock()
    {
        if (isClavierscreenClock.isOn)
        {
            ShowLayout(AzertLayoutBig);
        }
        else
        {
            ShowLayout(AzertLayoutSml);
        }
    }
    public void CloseAllLayouts()
    {

     
        SymbLayout.SetActive(false);
        AzertLayoutSml.SetActive(false);
        AzertLayoutBig.SetActive(false);
        TexteActiver.SetActive(false);



    }

    public void ShowLayout(GameObject SetLayout)
    {

        CloseAllLayouts();
        SetLayout.SetActive(true);
        TexteActiver.SetActive(true);

    }

}
