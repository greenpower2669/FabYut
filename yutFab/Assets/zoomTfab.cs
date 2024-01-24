using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomTfab : MonoBehaviour
{
    public float zoomFactor = 2.0f; // Facteur de zoom, 2.0 pour un zoom �2
    public Camera mainCamera; // R�f�rence � la cam�ra que vous souhaitez zoomer
    public Transform target; // Transform de l'objet que vous souhaitez zoomer
    public float angleThreshold = 45.0f; // Seuil d'angle pour r�initialiser le zoom

    private float initialFOV;

    void Start()
    {
        if (mainCamera != null)
        {
            initialFOV = mainCamera.fieldOfView;
        }
    }

    void Update()
    {
        if (target != null && mainCamera != null)
        {
            Vector3 targetPosition = target.position;
            mainCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, mainCamera.transform.position.z);

            // Calcul de l'angle entre la cam�ra et la cible
            Vector3 toTarget = targetPosition - mainCamera.transform.position;
            float angleToTarget = Vector3.Angle(mainCamera.transform.forward, toTarget);

            if (angleToTarget > angleThreshold)
            {
                // R�initialiser le champ de vision � sa valeur initiale
                mainCamera.fieldOfView = initialFOV;
            }
            else
            {
                // Ajuster le champ de vision en fonction du facteur de zoom
                mainCamera.fieldOfView = initialFOV / zoomFactor;
            }
        }
    }
}
