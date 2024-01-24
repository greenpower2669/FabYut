using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotaauraFab : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float sizeVariationAmount = 0.01f;
    public float heightVariationAmount = 0.01f;

    private Vector3 initialScale;
    private float initialYPosition;

    void Start()
    {
        // Sauvegarde de l'échelle et de la position initiales
        initialScale = transform.localScale;
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        // Rotation autour de l'axe Z
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // Variation de la taille
        float sizeVariation = Mathf.Sin(Time.time) * sizeVariationAmount;
        transform.localScale = initialScale + new Vector3(sizeVariation, sizeVariation, 0f);

        // Variation de la hauteur
        float heightVariation = Mathf.Cos(Time.time) * heightVariationAmount;
        transform.position = new Vector3(transform.position.x, initialYPosition + heightVariation, transform.position.z);
    }
}
