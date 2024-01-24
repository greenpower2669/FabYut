using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabFalling : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform myTransform;
    private bool isFalling = false;
    private Vector3 initialRotation;
    private float minRotationSpeed = 10f;
    private float maxRotationSpeed = 50f;

    void Start()
    {
        myTransform = transform;
        initialRotation = myTransform.eulerAngles;
    }

    void Update()
    {
        if (!isFalling)
        {
            // Si l'objet est en train de tomber (variation négative de la position Y), activez la rotation aléatoire.
            if (myTransform.position.y < initialRotation.y)
            {
                isFalling = true;
                float randomSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
                Vector3 randomRotation = new Vector3(
                    Random.Range(0, 360),
                    Random.Range(0, 360),
                    Random.Range(0, 360)
                );
                StartCoroutine(RotateObject(randomSpeed, randomRotation));
            }
        }
    }

    IEnumerator RotateObject(float speed, Vector3 rotation)
    {
        while (isFalling)
        {
            myTransform.Rotate(rotation * speed * Time.deltaTime);
            yield return null;
        }
    }
}
