
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class fabOpenKB : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    public TMP_InputField textArea;

    // M�thode publique pour ouvrir le clavier
    public void OpenKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    void Start()
    {
        // Appeler la m�thode pour ouvrir le clavier
        OpenKeyboard();
    }

    void Update()
    {
        // Si le clavier est ferm�
        if (keyboard != null && !keyboard.active)
        {
            // Remplir le champ de saisie avec la valeur du clavier
            textArea.text = keyboard.text;
        }
    }
}



