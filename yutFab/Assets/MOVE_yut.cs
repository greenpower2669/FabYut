using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE_yut : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float touchForce = 10.0f;
    public float mouseClickForce = 50.0f;
    public float touchDownForce = 30.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseOver()
    {
        // Lorsque la souris survole l'objet, appliquez une force vers le haut
        rb.AddForce(Camera.main.transform.up * mouseClickForce, ForceMode.Impulse);
    }

    void OnTouchEnter()
    {
        // Lorsque l'écran tactile est utilisé sur l'objet, appliquez une force dans la direction du point de contact
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Supposons que vous utilisez le premier touché détecté
            Vector3 touchPoint = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10.0f)); // 10.0f est la distance de la caméra
            Vector3 forceDirection = (touchPoint - transform.position).normalized;
            rb.AddForce(forceDirection * touchDownForce, ForceMode.Impulse);
        }
    }

    void OnTouchExit()
    {
        // Réinitialisez l'objet lorsque le toucher quitte l'objet
        // Vous pouvez laisser cette fonction vide ou ajouter un code personnalisé pour réinitialiser l'objet.
    }
}
