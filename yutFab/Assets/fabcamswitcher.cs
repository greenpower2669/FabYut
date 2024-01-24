using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabcamswitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Object1;
    public Transform Object2;
    public Transform Object3;
    public Camera Camera1; // Caméra par défaut
    public Camera Camera2; // Caméra vers laquelle basculer

    public float maxHeight = 5.0f; // Hauteur maximale à partir de laquelle basculer

    private Camera currentCamera;

    void Start()
    {
        currentCamera = Camera1; // La caméra par défaut est active au démarrage
        Camera1.enabled = true;
        Camera2.enabled = false;
    }

    void Update()
    {
        // Vérifiez la hauteur de chaque objet
        if (Object1.position.y >= maxHeight || Object2.position.y >= maxHeight || Object3.position.y >= maxHeight)
        {
            // Basculez vers l'autre caméra
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        // Désactivez la caméra actuelle et activez l'autre
        currentCamera.enabled = false;
        currentCamera = (currentCamera == Camera1) ? Camera2 : Camera1;
        currentCamera.enabled = true;
    }

}
