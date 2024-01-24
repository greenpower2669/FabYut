using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabcamswitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Object1;
    public Transform Object2;
    public Transform Object3;
    public Camera Camera1; // Cam�ra par d�faut
    public Camera Camera2; // Cam�ra vers laquelle basculer

    public float maxHeight = 5.0f; // Hauteur maximale � partir de laquelle basculer

    private Camera currentCamera;

    void Start()
    {
        currentCamera = Camera1; // La cam�ra par d�faut est active au d�marrage
        Camera1.enabled = true;
        Camera2.enabled = false;
    }

    void Update()
    {
        // V�rifiez la hauteur de chaque objet
        if (Object1.position.y >= maxHeight || Object2.position.y >= maxHeight || Object3.position.y >= maxHeight)
        {
            // Basculez vers l'autre cam�ra
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        // D�sactivez la cam�ra actuelle et activez l'autre
        currentCamera.enabled = false;
        currentCamera = (currentCamera == Camera1) ? Camera2 : Camera1;
        currentCamera.enabled = true;
    }

}
