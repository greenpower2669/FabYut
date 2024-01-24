using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabDragable : MonoBehaviour
{
    // Start is called before the first frame update
    public float vitesseDeplacement = 5.0f;

    private Camera cameraEnCours; // Référence à la caméra en cours

    private Vector3 lastMousePosition;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
        cameraEnCours = Camera.main; // Définir la caméra principale comme caméra en cours au démarrage
    }

    void Update()
    {
        // Mettre à jour la caméra en cours si elle change en cours de jeu
        if (Camera.main != cameraEnCours)
        {
            cameraEnCours = Camera.main;
        }

        // Vérifier que nous avons une caméra valide
        if (cameraEnCours == null)
        {
            return; // Si aucune caméra n'est disponible, ne rien faire
        }

        // Obtenez la position actuelle de la souris
        Vector3 currentMousePosition = Input.mousePosition;

        // Calculez la différence entre la position actuelle de la souris et la position précédente de la souris
        Vector3 mouseDelta = currentMousePosition - lastMousePosition;

        // Convertir les coordonnées de la souris en coordonnées dans l'espace du monde (utilisez la profondeur z pour le positionnement sur l'axe Z)
        mouseDelta.z = cameraEnCours.transform.position.y; // Utiliser la hauteur de la caméra comme profondeur
        mouseDelta = cameraEnCours.ScreenToWorldPoint(mouseDelta);
        mouseDelta.y = 0;

        // Effectuer le déplacement de l'objet sur les axes x et z en fonction du déplacement de la souris
        Vector3 translation = mouseDelta - transform.position;
        transform.Translate(translation * vitesseDeplacement * Time.deltaTime);

        // Mettez à jour la position précédente de la souris
        lastMousePosition = currentMousePosition;
    }
}
