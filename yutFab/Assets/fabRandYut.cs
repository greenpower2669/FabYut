using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabRandYut : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform myTransform;

    // Angle initial Z
    private float initialAngleZ;

    // Variation minimale et maximale
    private float minVariation = 0.8f;
    private float maxVariation = 1.2f;

    void Start()
    {
        myTransform = transform;

        // Sauvegarde de l'angle Z initial
        initialAngleZ = myTransform.eulerAngles.z;

        // Appel de la fonction pour changer l'angle Z de manière aléatoire
        ChangeRandomAngleZ();
    }

    void ChangeRandomAngleZ()
    {
        // Générer une variation aléatoire entre minVariation et maxVariation
        float randomVariation = Random.Range(minVariation, maxVariation);

        // Calculer le nouvel angle Z en ajoutant la variation à l'angle initial
        float newAngleZ = initialAngleZ + randomVariation;

        // Appliquer la rotation à l'objet
        Vector3 newRotation = myTransform.eulerAngles;
        newRotation.z = newAngleZ;
        myTransform.eulerAngles = newRotation;
    }
}
