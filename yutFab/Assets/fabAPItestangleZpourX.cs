using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabcopieYpourX : MonoBehaviour
{
    Vector3 currentEulerAngles;
    public Transform sourceObject; // L'objet dont vous souhaitez copier la rotation
    public Transform targetObject; // L'objet auquel vous souhaitez appliquer la rotation
    public Vector3 rotationCorrection = Vector3.zero; // Correcteur de rotation sur les axes X, Y et Z en degrés
    public Vector3 Rotation = Vector3.zero;
    public bool copierRotationX = true; // Copier la rotation sur l'axe X
    public bool copierRotationY = true; // Copier la rotation sur l'axe Y
    public bool copierRotationZ = true; // Copier la rotation sur l'axe Z
    float rotationSpeed = 45;

    float x;
    float y;
    float z;

    private void Start()
    {
        // currentEulerAngles += new Vector3(targetObject.eulerAngles.x , 0, 0);
        //apply the change to the gameObject
        //transform.eulerAngles = currentEulerAngles;
        InvokeRepeating("MyUpdate", 0f, 0.1f);
        //currentEulerAngles = new Vector3(-90, transform.eulerAngles.y, transform.eulerAngles.z);
    }
    private void MyUpdate()
    {

        if (sourceObject != null && targetObject != null)

        {

            Vector3 newRotation = targetObject.rotation.eulerAngles;

            if (copierRotationX)
            {
                newRotation.x = sourceObject.rotation.eulerAngles.x + rotationCorrection.x;
            }
            else
            {
                newRotation.x = Rotation.x;
            }

            if (copierRotationY)
            {
                newRotation.y = sourceObject.rotation.eulerAngles.y + rotationCorrection.y;
            }
            else
            {
                newRotation.y = Rotation.y;
            }
            if (copierRotationZ)
            {
                newRotation.z = sourceObject.rotation.eulerAngles.z + rotationCorrection.z;
            }
            else
            {
                newRotation.z = Rotation.z;
            }
            float newZ = sourceObject.rotation.eulerAngles.z;
            //targetObject.rotation = Quaternion.Euler(newRotation);
            //modifying the Vector3, based on input multiplied by speed and time
            currentEulerAngles = new Vector3(0, 0, newZ);//sourceObject.rotation.eulerAngles.z);

            //apply the change to the gameObject
            transform.eulerAngles = currentEulerAngles;
        }
    }

}
