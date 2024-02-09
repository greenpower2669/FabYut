#if UNITY_WEBGL
#pragma warning disable
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class fabcamSw : MonoBehaviour
{
    public Slider slider;
    public float minZoom=30f;
    public float maxZoom = 60f;
    private float zoomFab;
    public TextMeshProUGUI textMeshFromObjectA;
    public TextMeshProUGUI textMeshFromObjectB;
    public Transform Object1;
    public Transform Object2;
    public Transform Object3;
    public Transform Object4;
    public Camera Camera1; // Cam�ra par d�faut
    public Camera Camera2; // Cam�ra vers laquelle basculer
    public Camera Cameraj1;
    public Camera Cameraj2;
    public float maxHeight = 5.0f; // Hauteur maximale � partir de laquelle basculer
    public int indexcam = 1;
    private Camera currentCamera;
    private Vector3[] initialPositions; // Tableau pour stocker les positions de d�part
    public float desiredHeight=8;
    private bool lunched = false;
    private bool processingfalldown=false;
    private bool processingfalldown0 = false;
    private Vector3[] previousPositions;
    public float movementThreshold = 0.01f; // Changer ceci selon votre tol�rance de mouvement.

    // Ajoutez ces variables pour la modification al�atoire de l'angle Z
    public float minVariation = -10.0f;
    public float maxVariation = 10.0f;
    public float minMassModifier = 0.5f;
    public float maxMassModifier = 2.0f;
    public string buttonTag = "suivant";
    public string buttonTagL = "lancer";
    public string buttonTagJ = "jouer";
    public int CountLeft = 0;
    public int CountLeft0 = 0;
    public bool CountLefted = false;
    private GameObject[] allObjects;
    private GameObject[] allObjectsL;
    private GameObject[] allObjectsJ;
    private int Player=2;
    private bool Rejouer04=false;
    private Transform[] objects;
    private TouchScreenKeyboard clavier;
    GameObject objetAChercher;
    Globals globalsScript;

    //joueurs: index is counted si le resultat du jet est connu.
    // lunchcount if left 0 then change player san game and change player  
    //Heavypart
    public struct Pions
    {
        public int id;
        public int Parcouru;
        public int joueur;
        public int YpA;
        public int YpB;
        public int Turnleft;
        public int LinkedA; // Champ ajout�
        public int LinkedB; // Champ ajout�
        public int LinkedC; // Champ ajout�
        public int LinkedD; // Champ ajout�
    }
    public void ResetGame()
    {
        
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");
        //Globals globalsScript = objetAChercher.GetComponent<Globals>();
        globalsScript.WinerId = 0;
        Player = 2;
        for (int i = 1; i <= 4; i++)
        {
            //globalsScript.SaveTurns[1, i] = 1;
            //globalsScript.SaveTurns[2, i] = 1;
            globalsScript.Pionraz[1, i] = true;
            globalsScript.Pionraz[2, i] = true;
        }
        JtoS(Player);
        ResetObjects();
        globalsScript.haveToComputing = true;

    }
    public void cheatm()
    {
        CountLeft = -1;
    }
    public void cheat1()
    {
        CountLeft = 1;
    }
    public void cheat2()
    {
        CountLeft = 2;
    }
    public void cheat3()
    {
        CountLeft = 3;
    }
    public void cheat4()
    {
        CountLeft = 4;
    }
    public void cheat5()
    {
        CountLeft = 5;
    }
    void Start()
    {
        objetAChercher = GameObject.FindWithTag("Globals");
        globalsScript = objetAChercher.GetComponent<Globals>();
        if (slider == null)
        {
           
            Debug.LogError("Le Slider n'est pas r�f�renc�.");
            return;
        }
        else { slider.value = 1; }
        // Trouver l'objet par son label (tag)
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");

        // V�rifier si l'objet a �t� trouv�
      
    
// globals init
objects = new Transform[] { Object1, Object2, Object3, Object4 };
        previousPositions = new Vector3[objects.Length];

        // Initialiser les positions pr�c�dentes.
        for (int i = 0; i < objects.Length; i++)
        {
            previousPositions[i] = objects[i].position;
        }
        // Enregistrez les positions de d�part
        initialPositions = new Vector3[4];
        initialPositions[0] = Object1.position;
        initialPositions[1] = Object2.position;
        initialPositions[2] = Object3.position;
        initialPositions[3] = Object4.position;
         allObjects = GameObject.FindGameObjectsWithTag(buttonTag);
        allObjectsL = GameObject.FindGameObjectsWithTag(buttonTagL);
        
        allObjectsJ = GameObject.FindGameObjectsWithTag(buttonTagJ);

         SwitchCamera();
        InvokeRepeating("myUpdate", 0f, 0.1f);
        InvokeRepeating("GameChecking", 0f, 0.5f);

        //heavypart
        //Pions[] pions; // Tableau de la structure Pions
        //GameObject[][] YutPaths;
    }
    public void Lunched()
    {
        lunched = true;
    }
    
    void GameChecking()
    {
        Aplat();
        JtoS(Player);
        processingfalldown0 = processingfalldown;
        processingfalldown = false;

        for (int i = 0; i < objects.Length; i++)
        {
            if (HasObjectMoved(objects[i], i))
            {
                processingfalldown = true;//Debug.Log("Object " + i + " a boug�.");
            }
        }

        for (int i = 0; i < objects.Length; i++)
        {
            previousPositions[i] = objects[i].position;
        }
        if (processingfalldown0 && lunched)
        {
            if (processingfalldown != processingfalldown0 && (CountLeft==0 || CountLeft==-9))
            {
                TestCountLeft();

            }
        }
        OnBoutonClicYutVerif();
        // ici le game cheking lourd en temps de proc�sseur
    }
    void myUpdate()
    {
        if (globalsScript.MinScreenSend)
        {

            if (CountLeft == 0)
            {
                fastResetObjects();
            }
            globalsScript.MinScreenSend = false;
        }
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");
        //Globals globalsScript = objetAChercher.GetComponent<Globals>();
        zoomFab = slider.value;
        globalsScript.Indexcam = indexcam;
        if (indexcam == 1) { globalsScript.Fived = false; CountLeft = -9; }
        float nouveauFOV = Mathf.Lerp(minZoom,maxZoom, slider.value); // Ajustez les valeurs minimales et maximales du FOV selon vos besoins
        Cameraj1.fieldOfView = nouveauFOV;
        Cameraj2.fieldOfView = nouveauFOV;
        // V�rifiez si l'une des cam�ras est activ�e
        bool auMoinsUneCameraActive = (Cameraj1.enabled || Cameraj2.enabled)&& globalsScript.MY;

        // D�sactivez le slider si aucune cam�ra n'est activ�e et que global my togle est on
        slider.gameObject.SetActive(auMoinsUneCameraActive);

        //  ici les temps de r�action attendus � 100 millisecondes
        // public bool afficher_lancer = false;
        // public bool lancer_a_Afficher = false;

      
       
        if (globalsScript.choosen)
        {
            CountLeft = 0;
            globalsScript.choosen = false;
            //CountLefted = false;

}
        globalsScript.CountLeft = CountLeft;
        if ((indexcam == 4 || indexcam == 3) && !processingfalldown0 && lunched)
        {
            if (CountLeft == 0 || (globalsScript.Fived && CountLeft==-50)) { globalsScript.afficher_lancer = true; globalsScript.lancer_a_Afficher = true; } else { globalsScript.afficher_lancer = false; globalsScript.lancer_a_Afficher = false; }
            if (globalsScript.afficher_lancer && globalsScript.lancer_a_Afficher)
            {
                if (!globalsScript.yutlist)
                {
                    globalsScript.lancer_a_Afficher = false;
                    if (globalsScript.autoL) { fastResetObjects(); }
                    else
                    {
                        AfficherBtlancer(true);
                    }
                }
                else
                {
                    CountLeft = -50;
                }
                

            }

          
          
        }
        // ici si pret � lancer alors attendre coups � jouer
    }
    void AfficherBtlancer(bool tf)
    {
        foreach (GameObject obj in allObjectsL)
        {
            // R�active l'objet
            obj.SetActive(tf);

        }

    }
    void Update()
    {
        // V�rifiez la hauteur de chaque objet
       
      
        bool shouldSwitch = false;

        if (CountLeft == -9|| CountLeft==-50) {
            if (CountLeft == -9)
            {
                textMeshFromObjectB.text = "Lanc� en cours ....";
            }
            else
            {//ce if � supromer car ne set pas le lanc� � reset
                
                     textMeshFromObjectB.text = "Faites votre choix!";
                
             
            }
        }
        else
        { textMeshFromObjectB.text = "Coups � jouer : " + CountLeft.ToString(); }
        if (Object1.position.y >= maxHeight || Object2.position.y >= maxHeight || Object3.position.y >= maxHeight || Object4.position.y >= maxHeight)
        {
            shouldSwitch = true;

        }

        if (shouldSwitch &&  Camera2.enabled)
        {
           
            indexcam = 1;
            SwitchCamera();
            // Parcourt tous les objets trouv�s et les r�active
          
        }
        else if (!shouldSwitch &&  Camera1.enabled)
        {
            CountLeft = -9;
            indexcam = 2;
            SwitchCamera();
         
        }
    }
    private bool HasObjectMoved(Transform obj, int index)
    {
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");
        //Globals globalsScript = objetAChercher.GetComponent<Globals>();
        if (!globalsScript.lancer_a_Afficher)
        { 
        // Calculer la diff�rence entre la position actuelle et la position pr�c�dente.
        float distance = Vector3.Distance(obj.position, previousPositions[index]);

        // Mettre � jour la position pr�c�dente.
        previousPositions[index] = obj.position;

        // Si la distance est sup�rieure � un seuil, l'objet a boug�.
        return distance > movementThreshold;
        }
        else
        { return false; }
    }
    void TestCountLeft()
    {
        bool minus = false;
        int Intermediaire = 0;
        Transform[] objects = { Object1, Object2, Object3, Object4 };

        for (int i = 0; i < objects.Length; i++)
        {
            Transform obj = objects[i];
            float rotationZ = obj.rotation.eulerAngles.z;

            // Ajouter 90/3 � chaque angle
            float rotatedAngle = rotationZ;// + 90.0f / 3;

            // V�rifier si l'angle se trouve entre 0 et 180
            //180 donc 160 200 :: 145 215 70DEG
            //Debug.Log("Object " + rotatedAngle + " proche de  180 ?");
            if (rotatedAngle >= 130 && rotatedAngle <= 230)
            {
                Intermediaire++;
                if (i == 0) { minus = true; }
               

            }
            else
            {
              // Ne pas incr�menter CountLeft 
            }
        }
        if (Intermediaire == 0) { Intermediaire = 5; }
        if (Intermediaire > 3) { Rejouer04 = true; }

        if (Intermediaire==1 && minus){ Intermediaire = -1; }
        CountLeft=Intermediaire;
        if ( globalsScript.Saved) //globalsScript.Jts != "Computer" &&
        {
            globalsScript.RobotStop = true;
            globalsScript.Saved = false;
            globalsScript.CountLeftDL = 50;

        }
        if ( (Intermediaire == 5 || Intermediaire == 4))
        {
            globalsScript.RobotStop = true;
            //YutVide() quand l'utiliser?
            // if (globalsScript.Jts != "Computer") { 
            globalsScript.CountLeftDL = 60; globalsScript.Fived = true; globalsScript.Saved = true;


             //       } else { globalsScript.Fived = true;
           // }
          


        }
      
        // Mettre � jour le texte de CountLeftText avec la valeur actuelle de CountLeft
        // CountLeftText.text = "CountLeft : " + CountLeft.ToString();
    }
    void switchPlayers()
    {
        globalsScript.RobotStop = false;
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");
        //Globals globalsScript = objetAChercher.GetComponent<Globals>();

        if (globalsScript.Fived) { globalsScript.Fived = false; } else {
            globalsScript.switchNames = true;
            if (Player == 1) { Player = 2;  globalsScript.Jid = 2; } else { Player = 1; globalsScript.Jid = 1; }
            if (textMeshFromObjectA != null)
            {
                JtoS(Player);
            }
        }
    }
    void JtoS(int p)
    {
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");
        //Globals globalsScript = objetAChercher.GetComponent<Globals>();
        // Mettez � jour le texte du TextMesh avec le nom du joueur  
        textMeshFromObjectA.text = globalsScript.libNameText + p.ToString();
    }
    void SwitchCamera()
    {

        foreach (GameObject obj in allObjects)
        {
            // d�active l'objet
            obj.SetActive(false);

        }
        AfficherBtlancer(false);
    
        foreach (GameObject obj in allObjectsJ)
        {
            // D�active l'objet
            obj.SetActive(false);

        }
        // Trouver tous les objets avec le tag "trape"
        GameObject[] yutObjects = GameObject.FindGameObjectsWithTag("trape");

        // Parcourir chaque objet trouv�
        foreach (GameObject yutObject in yutObjects)
        {
            trape trapeComponent = yutObject.GetComponent<trape>();

            if (trapeComponent != null)
            {
                // � false la valeur de la variable "IsOpen"
                yutObject.GetComponent<trape>().isOpen = false;
                // Recherche le GameObject avec le tag sp�cifi�.



            }
        }
        // Activez la cam�ra en fonction de l'index
        Camera1.enabled = false;
        Camera2.enabled = false;
        Cameraj1.enabled = false;
        Cameraj2.enabled = false;
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");
        //Globals globalsScript = objetAChercher.GetComponent<Globals>();
        switch (indexcam)
        { 
            case 1:
                switchPlayers();
                Camera1.enabled = true;
                foreach (GameObject obj in allObjects)
                {
                    // R�active l'objet
                    obj.SetActive(true);

                }
                break;
            case 2:
              
                foreach (GameObject obj in allObjectsJ)
                {
                    // R�active l'objet
                    obj.SetActive(true);

                }
                Camera2.enabled = true;
                break;
            case 3:
            
                globalsScript.lancer_a_Afficher = true;
     
                Cameraj1.enabled = true;
                break;
            case 4:
               
                globalsScript.lancer_a_Afficher = true;
        
                Cameraj2.enabled = true;
                break;

                // D�sactivez la cam�ra actuelle et activez l'autre
                //currentCamera.enabled = !currentCamera.enabled;
                //currentCamera = (currentCamera == Camera1) ? Camera2 : Camera1;
                //currentCamera.enabled = !currentCamera.enabled;
        }
    }
    public void tSCR()
    {
        clavier= TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        
    }
    public void Jouer()
    {
       
        switshPlayerCam();


        SwitchCamera();
        AfficherBtlancer(false);

      
    }
        // M�thode pour r�initialiser les objets � leurs positions de d�part
        public void ResetObjects()
    {
        // Trouver tous les objets avec le tag sp�cifi�, y compris les objets d�sactiv�s


        CountLeft = -9;

        indexcam = 1;
        
        SwitchCamera();
        //Debug.Log("Nombre de boutons trouv�s : " + allObjects.Length);
        Object1.position = initialPositions[0];
        Object2.position = initialPositions[1];
        Object3.position = initialPositions[2];
        Object4.position = initialPositions[3];

        
     
        // Appelez la m�thode pour modifier l'angle Z al�atoirement
        ChangeRandomAngleZ(Object1);
        ChangeRandomAngleZ(Object2);
        ChangeRandomAngleZ(Object3);
        ChangeRandomAngleZ(Object4);
        
    }
    IEnumerator WaitFab()
    {
        // Attendre 100ms
        yield return new WaitForSeconds(1f);

     
    }
    public void reset()
    {
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");
        //Globals globalsScript = objetAChercher.GetComponent<Globals>();
        globalsScript.uiState = -1;
        indexcam = 1;
        fastResetObjects();
    }
    void switshPlayerCam()
    {
        if (Player == 1)
        {
            indexcam = 3;
        }
        if (Player == 2)
        {
            indexcam = 4;
        }
    }
    void Aplat()
    {
        float tolerance = 10f; // D�finissez votre tol�rance personnalis�e ici

        for (int ii = 0; ii < objects.Length; ii++)
        {
            // Modifiez la position en hauteur pour chaque objet
            int iii = ii + 2;

            // Condition : V�rifier si la hauteur est en dessous de 1.7
            if (objects[ii].position.y < 1.7f)
            {
                // Condition : Si la hauteur est en dessous de 1.7, v�rifiez la rotation x avec une tol�rance
                if (Mathf.Abs(objects[ii].rotation.eulerAngles.x - 270f) < tolerance || Mathf.Abs(objects[ii].rotation.eulerAngles.x - 90f) < tolerance)
                {
                    // Si la rotation x est proche de 360 ou 180, donnez un coup de pouce en ajoutant 45 degr�s � la rotation x
                    objects[ii].rotation = Quaternion.Euler(objects[ii].rotation.eulerAngles.x + 45f, objects[ii].rotation.eulerAngles.y, objects[ii].rotation.eulerAngles.z);
                }
            }

            // Modifiez la position en hauteur pour chaque objet
           // objects[ii].position = new Vector3(objects[ii].position.x + (iii * 0.4f - 1.5f - objects[ii].position.x), objects[ii].position.y + desiredHeight * 2 * iii, objects[ii].position.z + (iii * 0.3f - 2.6f - objects[ii].position.z));
        }
    }


    public void fastResetObjects()
    {

        switchPlayers();
        switshPlayerCam();
        SwitchCamera();


        for (int ii = 0; ii < objects.Length; ii++)
            {
            // Modifiez la position en hauteur pour chaque objet
            int iii = ii + 2;
                objects[ii].position  = new Vector3(objects[ii].position.x+(iii * 0.4f-1.5f - objects[ii].position.x), objects[ii].position.y + desiredHeight*2*iii, objects[ii].position.z+(iii*0.3f-2.6f-objects[ii].position.z));
                //Object1.position = new Vector3(Object1.position.x, Object1.position.x + moveIntensity, Object1.position.z);
                //Object2.position = new Vector3(Object2.position.x, Object2.position.x + moveIntensity, Object2.position.z);
                //Object3.position = new Vector3(Object3.position.x, Object3.position.x + moveIntensity, Object3.position.z);
                //Object4.position = new Vector3(Object4.position.x, Object4.position.x + moveIntensity, Object4.position.z);
            }



        CountLeft = -9;
        // /grav
        // Appelez la m�thode pour modifier l'angle Z al�atoirement
        ChangeRandomAngleZ(Object1);
        ChangeRandomAngleZ(Object2);
        ChangeRandomAngleZ(Object3);
        ChangeRandomAngleZ(Object4);
        Lunched();
      
        AfficherBtlancer(false);
        //GameObject objetAChercher = GameObject.FindWithTag("Globals");
        //Globals globalsScript = objetAChercher.GetComponent<Globals>();
        globalsScript.lancer_a_Afficher = true;
        
    }
    // M�thode pour modifier l'angle Z al�atoirement
    private void ChangeRandomAngleZ(Transform myTransform)
    {
        // G�n�rer une variation al�atoire entre minVariation et maxVariation
        float randomVariation = Random.Range(minVariation, maxVariation);
        float randomVariationb = Random.Range(minVariation, maxVariation);
        // G�n�rer un modificateur de masse al�atoire
        float randomMassModifier = Random.Range(minMassModifier, maxMassModifier);

        // Calculer le nouvel angle Z en ajoutant la variation � l'angle initial
        float newAngleZ = myTransform.eulerAngles.z + randomVariation;
        float newAngleZb = myTransform.eulerAngles.y + randomVariationb;
        // Appliquer la rotation � l'objet
        Vector3 newRotation = myTransform.eulerAngles;
        newRotation.z = newAngleZ; newRotation.y = newAngleZb;
        myTransform.eulerAngles = newRotation;

        // Appliquer le modificateur de masse
        myTransform.GetComponent<Rigidbody>().mass *= randomMassModifier;
    }
    void OnBoutonClicYutVerif()
    {
       
  
        if (globalsScript.CountLeftDL != 0)
        {
            if (globalsScript.CountLeftDL==50 || globalsScript.CountLeftDL == 60) {
                if (globalsScript.CountLeftDL == 50) 
                {
                    globalsScript.SaveCountLeft(CountLeft); globalsScript.CountLeftDL = -50;
                } 
                 else 
                {
                globalsScript.SaveCountLeft(CountLeft); globalsScript.CountLeftDL = 0; globalsScript.choosen = true;
                }

                
            }
            else
            {
                CountLeft = globalsScript.CountLeftDL;
                globalsScript.CountLeftDL = 0;
            }
           
            
        }
      
        
       
    }
}
