using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trape : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public float closeSpeed = 4f; // Nouvelle vitesse de fermeture
    public bool isOpen = false;
    private float openSpeedC;
    public void openTrape()
    {
        isOpen = !isOpen;
    }
    void Start()
    {
        openSpeedC = openSpeed;
    }
    void Update()
        
      
{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOpen = !isOpen;

        }
        // Change la vitesse en fonction de l'état actuel
        if (isOpen)
        {
            openSpeedC = openSpeed;
        }
        else
        {
            openSpeedC = closeSpeed;
        }
        float currentAngleY = transform.localRotation.eulerAngles.y;
        float currentAngleZ = transform.localRotation.eulerAngles.z;
        float targetAngle = isOpen ? openAngle : 0f;
        Quaternion targetRotation = Quaternion.Euler(targetAngle, currentAngleY, currentAngleZ);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * openSpeedC);
    }
}
