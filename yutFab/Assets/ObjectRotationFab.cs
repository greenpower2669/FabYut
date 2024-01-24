using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationFab : MonoBehaviour
{
    public GameObject targetObject; // Référence à l'objet que vous souhaitez contrôler
    public Camera targetCamera; // Référence à la caméra
    public float sensitivity = 0.2f;

    private Vector2 lastMousePosition;
    private bool isRotating = false;

    private float initialRotationX;
    private float initialRotationY;

    void Start()
    {
        // Enregistrez les angles initiaux de l'objet lorsqu'il démarre.
        initialRotationX = targetObject.transform.rotation.eulerAngles.x;
        initialRotationY = targetObject.transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();
        // Vérifiez si la caméra est active
        if (targetCamera != null && targetCamera.enabled)
        {
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                isRotating = true;
                lastMousePosition = Input.mousePosition;
            }

            if (isRotating && !globalsScript.grabed && globalsScript.MY)
            {
                Vector2 currentMousePosition;

                if (Input.GetMouseButton(0))
                {
                    currentMousePosition = Input.mousePosition;
                }
                else if (Input.touchCount > 0)
                {
                    currentMousePosition = Input.GetTouch(0).position;
                }
                else
                {
                    isRotating = false;
                    return;
                }

                Vector2 mouseDelta = currentMousePosition - lastMousePosition;

                float rotationX = initialRotationX - mouseDelta.y * sensitivity;
                initialRotationX = initialRotationX - mouseDelta.y * sensitivity;
                initialRotationY = initialRotationY + mouseDelta.x * sensitivity;

                rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f);

                targetObject.transform.rotation = Quaternion.Euler(initialRotationX, initialRotationY, 0);

                lastMousePosition = currentMousePosition;
            }

            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                isRotating = false;
                // Mettez à jour les angles initiaux avec les nouvelles valeurs après la rotation.
                initialRotationX = targetObject.transform.rotation.eulerAngles.x;
                initialRotationY = targetObject.transform.rotation.eulerAngles.y;
            }
        }
    }

}
