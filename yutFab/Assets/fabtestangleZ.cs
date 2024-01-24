using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabtestangleZ : MonoBehaviour
{
    public Transform sourceObject; // R�f�rence � l'objet source dans l'inspecteur Unity
    public Transform targetObject; // R�f�rence � l'objet cible dans l'inspecteur Unity

    private void Update()
    {
        if (sourceObject != null && targetObject != null)
        {
            // R�cup�re l'angle Z de l'objet source
            float sourceZRotation = sourceObject.eulerAngles.z;

            // R�cup�re l'angle de rotation Z actuel de l'objet cible
            Vector3 targetEulerAngles = targetObject.eulerAngles;

            // Met � jour uniquement l'angle Z de l'objet cible
            targetEulerAngles.z = sourceZRotation;

            // Applique la nouvelle rotation Z � l'objet cible
            targetObject.eulerAngles = targetEulerAngles;
        }
    }
}