using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabtestangleZ : MonoBehaviour
{
    public Transform sourceObject; // Référence à l'objet source dans l'inspecteur Unity
    public Transform targetObject; // Référence à l'objet cible dans l'inspecteur Unity

    private void Update()
    {
        if (sourceObject != null && targetObject != null)
        {
            // Récupère l'angle Z de l'objet source
            float sourceZRotation = sourceObject.eulerAngles.z;

            // Récupère l'angle de rotation Z actuel de l'objet cible
            Vector3 targetEulerAngles = targetObject.eulerAngles;

            // Met à jour uniquement l'angle Z de l'objet cible
            targetEulerAngles.z = sourceZRotation;

            // Applique la nouvelle rotation Z à l'objet cible
            targetObject.eulerAngles = targetEulerAngles;
        }
    }
}