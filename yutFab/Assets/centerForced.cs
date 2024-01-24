using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerForced : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Calcule le centre du maillage de l'objet
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3 center = mesh.bounds.center;

        // Déplace le pivot de l'objet au centre du maillage
        transform.position = center;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
