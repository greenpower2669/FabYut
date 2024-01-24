using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fabUI : MonoBehaviour
{
    public bool Top = true;
    public Canvas TopC;
    public bool uiStart = true;
    public Canvas uiStartC;
    public bool End = false;
    public Canvas EndC;
    public bool Info = false;
    public Canvas InfoC;
    public bool Rouage = false;
    public Canvas RouageC;
    public ScrollRect InfoCSV;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("myUpdate5", 0f, 0.5f);
    }
    private void off(int ui) {
        bool state = false;
        if (ui != 1)
        {
            Rouage = state;
            RouageC.enabled = state;
        }
        if (ui != 2)
        {
            Info = state;
            InfoC.enabled = state;
            
        }


    }
    private void convertUI(int ui)
    {
       
        
        if (ui == 1)
        {
            
            Info = !Info;
            InfoC.enabled = Info;
            InfoCSV.verticalNormalizedPosition = 1f;
        }
        if (ui == 2)
        {

            Rouage = !Rouage;
            RouageC.enabled = Rouage;
        }
        if (ui == 3)
        {

            End = !End;
            EndC.enabled = End;
        }
        if (ui == 4)
        {

            uiStart = false;
            uiStartC.enabled = uiStart;
        }
        //off(ui);
    } 
    // Update is called once per frame
    void myUpdate5()
    {
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();

        if (globalsScript.uiState >0)
        {
            convertUI(globalsScript.uiState);
            globalsScript.uiState = 0;

        }
    }
}
