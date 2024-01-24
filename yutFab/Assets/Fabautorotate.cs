using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabautorotate : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // Axe de rotation (par exemple, Vector3.up pour l'axe Y)
    public float rotationAngle = 45f; // Angle de rotation � chaque it�ration
    public float rotationInterval = 0.5f; // Intervalle de temps entre chaque rotation en secondes
    public bool clockwise = true; // Sens de rotation

    private void Start()
    {
        // D�marre une coroutine pour g�rer la rotation � intervalles r�guliers
        StartCoroutine(RotateAtInterval());
    }

    private IEnumerator RotateAtInterval()
    {
        while (true)
        {
            // D�termine la direction de rotation en fonction du param�tre "clockwise"
            float direction = clockwise ? 1f : -1f;

            // Effectue la rotation autour de l'axe sp�cifi�
            transform.Rotate(rotationAxis, direction * rotationAngle);

            // Attend le prochain intervalle de rotation
            yield return new WaitForSeconds(rotationInterval);
        }
    }
}
