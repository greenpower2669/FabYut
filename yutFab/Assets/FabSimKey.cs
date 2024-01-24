using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabSimKey : MonoBehaviour
{
    public KeyCode keyToSimulate = KeyCode.Space;
    public string buttonTag = "suivant";
    void start()
    {

    }
    public void spaceB()
    {
        // Trouver tous les objets avec le tag "yut"
        GameObject[] yutObjects = GameObject.FindGameObjectsWithTag("trape");

        // Parcourir chaque objet trouvé
        foreach (GameObject yutObject in yutObjects)
        {
            trape trapeComponent = yutObject.GetComponent<trape>();

            if (trapeComponent != null)
            {
                // Inverser la valeur de la variable "IsOpen"
                yutObject.GetComponent<trape>().isOpen = !yutObject.GetComponent<trape>().isOpen;

            }
        }
    }

}

