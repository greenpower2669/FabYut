#if UNITY_WEBGL
#pragma warning disable
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabchoc : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cameraDeJeu; // Référence à la caméra de votre choix
    public int JId = 0;
    public int PId = 0;
    public int x = 0;
    public int y = 0;
    private RaycastHit hitInfo;
    private bool isDragging = false;
    public int Turnleft = 1;
    public int value = 1;
    public int Live = 1;
    public bool alive=true;
    public int Indexcam = 1;
    void Start()
    {
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();
        globalsScript.pJpoueurs[PId, JId, 0] = x;
        globalsScript.pJpoueurs[PId, JId, 1] = y;
        for (int i = 1; i <= 4; i++)
        {
            globalsScript.Pionlinked[JId, PId,i] = false;
            globalsScript.Piontokill[JId, i] = false;
            globalsScript.Pionraz[JId, i] = false;
        }
        InvokeRepeating("myUpdate", 0f, 0.1f);
    }
    void wined()
    {

    }
    void myUpdate()
    {
       
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();
        if (1 == 2) {
        if (globalsScript.PionturnsPlus[JId, PId])
        {
            globalsScript.PionturnsPlus[JId, PId] = false;
            value -= 1;
        }
        if (globalsScript.PionturnsMinus[JId, PId])
        {
            globalsScript.PionturnsMinus[JId, PId] = false;
            if (value < 1) { value += 1; }
            else { 
            
                globalsScript.Turnwin[JId-1] -= value;
                // 

                if (globalsScript.Turnwin[JId - 1] <1) { wined();} else { 
                        globalsScript.Piontokill[JId, PId] = true;
                    for (int i = 1; i <= 4; i++)
                    {

                        if (globalsScript.Pionlinked[JId, PId, i])

                        {
                            globalsScript.Piontokill[JId, i] = true;
                           
                            globalsScript.Pionlinked[JId, PId, i] = false;
                        }
                    }
                }
            }
        }
        }
        globalsScript.Pionturns[JId, PId] = value;
        if (globalsScript.Pionraz[JId, PId]) {
            Turnleft = 1;
            x = 0;y = 0; globalsScript.Pionraz[JId, PId] = false;
            globalsScript.pJpoueurs[PId, JId, 0] = x;
            globalsScript.pJpoueurs[PId, JId, 1] = y;
            value = 1;
            globalsScript.Pionturns[JId, PId] = value;
            Vector2 valeur = globalsScript.CooListSansH[x, y];

            // Faites quelque chose avec la valeur récupérée
            // Par exemple, affectez la position d'un autre objet

            transform.position = new Vector3(valeur.x, transform.position.y, valeur.y);
            for (int i = 1; i <= 4; i++)
            {

                if (globalsScript.Pionlinked[JId, PId, i])

                {
                    globalsScript.Pionraz[JId, i] = true;
                    globalsScript.Pionlinked[JId, PId, i] = false;
                }
            }

        }
       
      
        if (globalsScript.Piontokill[JId, PId]) {

            Turnleft = 0;
            value = 0;
            x = 30+JId; y = 30+PId; globalsScript.Piontokill[JId, PId] = false;

            globalsScript.pJpoueurs[PId, JId, 0] = x;
            globalsScript.pJpoueurs[PId, JId, 1] = y;
            Vector2 valeur = globalsScript.CooListSansH[x, y];

            // Faites quelque chose avec la valeur récupérée
            // Par exemple, affectez la position d'un autre objet

            transform.position = new Vector3(valeur.x, transform.position.y, valeur.y);
        }
      globalsScript.SaveTrigs[JId, PId]=(x,y);

        globalsScript.SaveTurns[JId, PId] = Turnleft;
     


    }
    void releaseGrab()
    {
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();
        isDragging = false;
        bool isDead = false;

        if ((globalsScript.trigIsPossible
            && globalsScript.trigIsPossibleX == globalsScript.trigX
            && globalsScript.trigIsPossibleY == globalsScript.trigY
             && globalsScript.trigIsPossibleX != 0)
               || (globalsScript.RobotChoosen && globalsScript.RobotPion == PId)
            )
        {
            
                globalsScript.haveToComputing = true;
            

            //si le trig est possible alors tester ce qui doit se passer à selon certains cas
            if ( 

                (
                globalsScript.trigX == 19 && globalsScript.trigY == 0 && (globalsScript.grabedX == 20 || globalsScript.grabedX == 0)
                )
                ||
                (
                globalsScript.trigX == 15 && globalsScript.trigY == 4 &&
                    (globalsScript.grabedX == 20 || globalsScript.grabedX == 0)
                )
               )
            {// tours en plus
                globalsScript.PionturnsPlus[JId, PId] = true;//selon la regle possible de faire n tours en plus au cas ou le linked est fait
                Turnleft += 1;
            }
            if (
                (
                (globalsScript.trigX == 20 || globalsScript.trigX == 1
                || globalsScript.trigX == 2 || globalsScript.trigX == 3
                || globalsScript.trigX == 4)
                && (globalsScript.trigY == 0 && globalsScript.grabedY == 0 &&
                globalsScript.grabedX < 20 && globalsScript.grabedX > 9)
                )
                ||
                (
                (globalsScript.trigX == 20 || globalsScript.trigX == 1
                || globalsScript.trigX == 2 || globalsScript.trigX == 3
                || globalsScript.trigX == 4)
                && (globalsScript.trigY == 0 && (globalsScript.grabedY == 3 || globalsScript.grabedY == 4)
                ))
             )



            {
                //Live += 1;
                Turnleft -= 1;
                if (Turnleft == 0)
                {
                    //kill
                    isDead = true;

                    globalsScript.Piontokill[JId, PId] = true;

                }

                globalsScript.PionturnsMinus[JId, PId] = true;//gagner?


            }
            x = globalsScript.trigIsPossibleX;
            y = globalsScript.trigIsPossibleY;
            globalsScript.choosen = true;
            globalsScript.toUntrig = true;
            globalsScript.toUntrigX = x;
            globalsScript.toUntrigY = y;
            int Other = 0;
            if (JId == 1)
            {
                Other = 2;
            }
            else { Other = 1; }
            globalsScript.pJpoueurs[PId, JId, 0] = x;
            globalsScript.pJpoueurs[PId, JId, 1] = y;
            // ne faire les test que si non killé
            if (Turnleft != 0)
            {// test de quoi,à l'arrivée


                for (int i = 1; i <= 4; i++)
                {
                    if ((i != PId) && (globalsScript.pJpoueurs[i, JId, 0] == x) && (globalsScript.pJpoueurs[i, JId, 1] == y))
                    {
                        globalsScript.Pionlinked[JId, PId, i] = true;

                        for (int ii = 1; ii <= 4; ii++)
                        {
                            if (globalsScript.Pionlinked[JId, i, ii])
                            {
                                globalsScript.Pionlinked[JId, PId, ii] = true;
                                value += 1;
                            }
                        }
                        globalsScript.Piontokill[JId, i] = true;
                        if (1 == 0)
                        { // bug enlevé, fonctionne?? le 17 12 2023

                            value += 1;
                            globalsScript.Pionturns[JId, PId] = value;
                        }
                    }

                    if ((globalsScript.pJpoueurs[i, Other, 0] == x) && (globalsScript.pJpoueurs[i, Other, 1] == y))
                    {
                        globalsScript.Pionraz[Other, i] = true;

                    }
                }
            }
            SetZeroVar();
        }
        if (globalsScript.Jts != "Computer")      {          SetZeroVar();        }
        
    }
    
    void SetZeroVar()
    {
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();

        globalsScript.RobotY = 0;
        globalsScript.RobotX = 0;
        globalsScript.RobotId = 0;
        globalsScript.RobotPion = 0;
        globalsScript.RobotChoosen = false;

        
        globalsScript.trigIsPossible = false;
        globalsScript.trigIsPossibleX = 0;
        globalsScript.trigIsPossibleY = 0;
        globalsScript.grabedPId = 0;
        globalsScript.grabedJId = 0;
        globalsScript.grabedX = 0;
        globalsScript.grabedY = 0;
        globalsScript.grabed = false;
    }
    void Update()
    {
        // Globals maj

        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        Globals globalsScript = objetAChercher.GetComponent<Globals>();
        if (globalsScript.RobotChoosen && globalsScript.Jts == "Computer" && globalsScript.RobotPion == PId && globalsScript.RobotId==JId) {
            releaseGrab(); 
        }
        if (globalsScript.computerChoiceid!=0) {
        // rentrer les conditions des globals
        }
        // /globalsmaj
        if (globalsScript.Jid == JId) { 
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                // Convertir les coordonnées de la souris ou du toucher en un rayon dans le monde
                Ray ray;
                if (Input.touchCount > 0)
                {
                    ray = cameraDeJeu.ScreenPointToRay(Input.GetTouch(0).position);
                }
                else
                {
                    ray = cameraDeJeu.ScreenPointToRay(Input.mousePosition);
                }

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.gameObject == this.gameObject)
                    {
                        isDragging = true;
                    }
                }
                globalsScript.trigIsPossible = false;
            }
 
            if (isDragging)
            {
                // globals
              
                    if (!globalsScript.grabed)
                    {
                    globalsScript.grabedPId =PId ;
                    globalsScript.grabedJId = JId;
                    globalsScript.grabedX = x;
                    globalsScript.grabedY = y;
                    globalsScript.grabed = true;

                    }
                // /globals
                if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    // Convertir les coordonnées de la souris ou du toucher en un rayon dans le monde
                    Ray ray;
                    if (Input.touchCount > 0)
                    {
                        ray = cameraDeJeu.ScreenPointToRay(Input.GetTouch(0).position);
                    }
                    else
                    {
                        ray = cameraDeJeu.ScreenPointToRay(Input.mousePosition);
                    }

                    // Déplacer l'objet uniquement sur les axes x et z
                    Vector3 targetPosition = ray.GetPoint(hitInfo.distance);
                    targetPosition.y = transform.position.y; // Conserver la position en y d'origine
                    transform.position = targetPosition;
                }

                if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
                {
                    releaseGrab();

                }
            }
            

        }
        if (!isDragging)
        {

            if (x == 0 && y == 0)
            {
                // Accédez aux données dans CooListSansH
                Vector2 valeur = globalsScript.CooListSansH[PId, 20 + JId];

                // Faites quelque chose avec la valeur récupérée
                // Par exemple, affectez la position d'un autre objet

                transform.position = new Vector3(valeur.x, transform.position.y, valeur.y);
            }
            else
            {


                // Accédez aux données dans CooListSansH
                Vector2 valeur = globalsScript.CooListSansH[x, y];

                // Faites quelque chose avec la valeur récupérée
                // Par exemple, affectez la position d'un autre objet

                transform.position = new Vector3(valeur.x, transform.position.y, valeur.y);
            }
        }
    }
}
