using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabCop4 : MonoBehaviour
{
    public Transform[] sourceObjects = new Transform[4]; // Tableau des objets dont vous souhaitez copier la rotation
    public Transform[] targetObjects = new Transform[4]; // Tableau des objets auxquels vous souhaitez appliquer la rotation
    public Vector3 rotationCorrection = Vector3.zero; // Correcteur de rotation sur les axes X, Y et Z en degrés
    public Vector3 Rotation = Vector3.zero;
    public bool copierRotationX = true; // Copier la rotation sur l'axe X
    public bool copierRotationY = true; // Copier la rotation sur l'axe Y
    public bool copierRotationZ = true; // Copier la rotation sur l'axe Z
    private void Start()
    {
        InvokeRepeating("heavy", 0f, 0.2f);
    }
    private void heavy()
    {
        for (int i = 0; i < sourceObjects.Length; i++)
        {
            if (sourceObjects[i] != null && targetObjects[i] != null)
            {
                Vector3 newRotation = targetObjects[i].rotation.eulerAngles;

                if (copierRotationX)
                {
                    newRotation.x = sourceObjects[i].rotation.eulerAngles.x + rotationCorrection.x;
                }
                else
                {
                    newRotation.x = Rotation.x;
                }

                if (copierRotationY)
                {
                    newRotation.y = sourceObjects[i].rotation.eulerAngles.y + rotationCorrection.y;
                }
                else
                {
                    newRotation.y = Rotation.y;
                }

                if (copierRotationZ)
                {
                    newRotation.z = sourceObjects[i].rotation.eulerAngles.z + rotationCorrection.z;
                }
                else
                {
                    newRotation.z = Rotation.z;
                }

                targetObjects[i].rotation = Quaternion.Euler(newRotation);
            }
        }
    }
}
