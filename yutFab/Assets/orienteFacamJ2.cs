using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orienteFacamJ2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity = 0.2f;

    private Vector2 lastMousePosition;
    private bool isRotating = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        if (isRotating)
        {
            Vector2 currentMousePosition;

            if (Input.GetMouseButton(1))
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

            float rotationX = transform.rotation.eulerAngles.x - mouseDelta.y * sensitivity;
            float rotationY = transform.rotation.eulerAngles.y + mouseDelta.x * sensitivity;

            //rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f);

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);

            lastMousePosition = currentMousePosition;

            if (Input.GetMouseButtonUp(1) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                isRotating = false;
            }
        }
    }
}
