using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabDragable : MonoBehaviour
{
    // Start is called before the first frame update
    public float vitesseDeplacement = 5.0f;

    private Camera cameraEnCours; // R�f�rence � la cam�ra en cours

    private Vector3 lastMousePosition;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
        cameraEnCours = Camera.main; // D�finir la cam�ra principale comme cam�ra en cours au d�marrage
    }

    void Update()
    {
        // Mettre � jour la cam�ra en cours si elle change en cours de jeu
        if (Camera.main != cameraEnCours)
        {
            cameraEnCours = Camera.main;
        }

        // V�rifier que nous avons une cam�ra valide
        if (cameraEnCours == null)
        {
            return; // Si aucune cam�ra n'est disponible, ne rien faire
        }

        // Obtenez la position actuelle de la souris
        Vector3 currentMousePosition = Input.mousePosition;

        // Calculez la diff�rence entre la position actuelle de la souris et la position pr�c�dente de la souris
        Vector3 mouseDelta = currentMousePosition - lastMousePosition;

        // Convertir les coordonn�es de la souris en coordonn�es dans l'espace du monde (utilisez la profondeur z pour le positionnement sur l'axe Z)
        mouseDelta.z = cameraEnCours.transform.position.y; // Utiliser la hauteur de la cam�ra comme profondeur
        mouseDelta = cameraEnCours.ScreenToWorldPoint(mouseDelta);
        mouseDelta.y = 0;

        // Effectuer le d�placement de l'objet sur les axes x et z en fonction du d�placement de la souris
        Vector3 translation = mouseDelta - transform.position;
        transform.Translate(translation * vitesseDeplacement * Time.deltaTime);

        // Mettez � jour la position pr�c�dente de la souris
        lastMousePosition = currentMousePosition;
    }
}
