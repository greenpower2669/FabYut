using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigActivateFab : MonoBehaviour
{
    public int trigX=0;
    public int trigY=0;
    // Noms des objets fils à activer/désactiver
    private string nomObjet1 = "aura";
    private string nomObjet2 = "aura (1)";
    private string nomObjet3 = "aura (2)";
    void Start()
    {
        InvokeRepeating("myUpdate", 0f, 0.1f);
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();
        // Récupérez les coordonnées de l'objet actuel (this.gameObject)
        Vector3 coordonnees = this.gameObject.transform.position;

        // Stockez les coordonnées (sauf la hauteur) dans la liste CooListSansH
        globalsScript.CooListSansH[trigX, trigY] = new Vector2(coordonnees.x, coordonnees.z);

    }
    // Update is called once per frame
    void myUpdate()
    {
        if (trigY < 20) { 
        // Globals maj  globalsScript.trigIsPossible &&
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();
        
        if (globalsScript.grabed && globalsScript.trigIsPossible
            && globalsScript.trigIsPossibleX== trigX && globalsScript.trigIsPossibleY== trigY
            && globalsScript.triged && (globalsScript.trigX == trigX) && (globalsScript.trigY == trigY))
        {

             ActiverDesactiverObjets(true); 
            // Activez les objets fils directement
            
        }
        if (globalsScript.toUntrig && globalsScript.toUntrigX==trigX && globalsScript.toUntrigY==trigY)
        {
            globalsScript.toUntrig = false;
            ActiverDesactiverObjets(false);
            globalsScript.toUntrigX = 0;
            globalsScript.toUntrigY = 0;
            globalsScript.triged = false;
            globalsScript.trigX = 0;
            globalsScript.trigY = 0;


        }
        }
    }
    // Méthode appelée lorsque le collider entre dans le trigger OnTriggerStay ??
    private void OnTriggerStay(Collider other)
    {
        if (trigY < 20)
        {
            GameObject objetAChercher = GameObject.FindWithTag("Globals");
            Globals globalsScript = objetAChercher.GetComponent<Globals>();
            if (globalsScript.grabed && (other.CompareTag("pav1") || other.CompareTag("pav2") || other.CompareTag("pav3") || other.CompareTag("pav4")))
            {
                if (!globalsScript.trigedb && globalsScript.trigedc && globalsScript.triged)
                {
                    globalsScript.trigX = trigX;
                    globalsScript.trigY = trigY;
                    globalsScript.triged = true;
                }



            }
        }
     }
    private void OnTriggerEnter(Collider other)
    {
        if (trigY < 20)
        {
            // Globals maj  globalsScript.trigIsPossible &&
            GameObject objetAChercher = GameObject.FindWithTag("Globals");
            Globals globalsScript = objetAChercher.GetComponent<Globals>();
            // Vérifiez si le collider qui entre dans le trigger est l'un des deux objets spécifiques
            if (globalsScript.grabed && (other.CompareTag("pav1") || other.CompareTag("pav2") || other.CompareTag("pav3") || other.CompareTag("pav4")))
            {

                if (!globalsScript.triged)
                {

                    globalsScript.trigX = trigX;
                    globalsScript.trigY = trigY;
                    globalsScript.triged = true;
                }
                else
                {
                    if (!globalsScript.trigedb)
                    {
                        globalsScript.trigXb = trigX;
                        globalsScript.trigYb = trigY;
                        globalsScript.trigedb = true;
                    }
                    else
                    {
                        globalsScript.trigXb = trigX;
                        globalsScript.trigYb = trigY;
                        globalsScript.trigedb = true;
                    }
                }
                if (globalsScript.triged && (globalsScript.trigX == trigX) && (globalsScript.trigY == trigY))
                {
                    // Activez les objets fils directement
                    //ActiverDesactiverObjets(true);
                }

            }
        }
    }

    // Méthode appelée lorsque le collider quitte le trigger
    private void OnTriggerExit(Collider other)
    {
        if (trigY < 20)
        {
            // Vérifiez si le collider qui quitte le trigger est l'un des deux objets spécifiques
            if (other.CompareTag("pav1") || other.CompareTag("pav2") || other.CompareTag("pav3") || other.CompareTag("pav4"))
            {
                GameObject objetAChercher = GameObject.FindWithTag("Globals");
                Globals globalsScript = objetAChercher.GetComponent<Globals>();
                if (globalsScript.triged && (globalsScript.trigX == trigX) && (globalsScript.trigY == trigY))
                {
                    globalsScript.trigX = 0;
                    globalsScript.trigY = 0;
                    globalsScript.triged = false;
                }

                if (globalsScript.trigedb && (globalsScript.trigXb == trigX) && (globalsScript.trigYb == trigY))
                {
                    globalsScript.trigXb = 0;
                    globalsScript.trigYb = 0;
                    globalsScript.trigedb = false;
                }

                if (globalsScript.trigedc && (globalsScript.trigXc == trigX) && (globalsScript.trigYc == trigY))
                {
                    globalsScript.trigXc = 0;
                    globalsScript.trigYc = 0;
                    globalsScript.trigedc = false;
                }
                // Désactivez les objets fils directement
                ActiverDesactiverObjets(false);
            }
        }
    }

    // Méthode pour activer ou désactiver les objets fils
    private void ActiverDesactiverObjets(bool activer)
    {
        transform.Find(nomObjet1)?.gameObject.SetActive(activer);
        transform.Find(nomObjet2)?.gameObject.SetActive(activer);
        transform.Find(nomObjet3)?.gameObject.SetActive(activer);
    }
}