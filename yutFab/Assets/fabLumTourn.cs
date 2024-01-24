using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabLumTourn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform centreRotation; // L'objet autour duquel la lumière tournera
    public float vitesseRotation = 45.0f; // Vitesse de rotation en degrés par seconde

    public bool activerWaveH = false; // Activer l'oscillation horizontale
    public float amplitudeWaveH = 0.5f; // Amplitude de l'oscillation horizontale
    public float frequenceWaveH = 1.0f; // Fréquence de l'oscillation horizontale

    public bool activerWaveV = false; // Activer l'oscillation verticale
    public float amplitudeWaveV = 0.2f; // Amplitude de l'oscillation verticale
    public float frequenceWaveV = 2.0f; // Fréquence de l'oscillation verticale

    private float horizontalOffset = 0f;
    private float verticalOffset = 0f;

    private void Update()
    {
        // Assurez-vous que le centre de rotation est défini
        if (centreRotation == null)
        {
            Debug.LogError("Le centre de rotation n'est pas défini. Veuillez assigner un objet dans l'inspecteur.");
            return;
        }

        // Calculez la rotation en fonction du temps
        float angle = vitesseRotation * Time.deltaTime;
        Vector3 axis = Vector3.up; // Vous pouvez changer l'axe de rotation selon vos besoins

        // Calculez l'oscillation horizontale
        if (activerWaveH)
        {
            horizontalOffset += Time.deltaTime * frequenceWaveH;
            float horizontalWave = Mathf.Sin(horizontalOffset) * amplitudeWaveH;
            transform.position += new Vector3(horizontalWave, 0f, 0f);
        }

        // Calculez l'oscillation verticale
        if (activerWaveV)
        {
            verticalOffset += Time.deltaTime * frequenceWaveV;
            float verticalWave = Mathf.Sin(verticalOffset) * amplitudeWaveV;
            transform.position += new Vector3(0f, verticalWave, 0f);
        }

        // Appliquez la rotation à la lumière
        transform.RotateAround(centreRotation.position, axis, angle);
    }
}
