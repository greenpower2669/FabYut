#if UNITY_WEBGL
#pragma warning disable
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class PushUpData
{
    public int p; // 1 ou 2
    public int y;
    public int x;
    

    public PushUpData(int pav, int y, int x)
    {
        this.p = pav;
        this.y = y;
        this.x = x;
        
    }
}
public class Globals : MonoBehaviour
{
    public int computerChoiceid = 0;
    public int computerChoiceX = 0;
    public int computerChoiceY = 0;
    private float startTime;
    public TextMeshProUGUI WinTxt;
    public bool grabed = false;
    public int grabedPId = 0;
    public int grabedJId = 0;
    public int grabedX = 0;
    public int grabedY = 0;
    public bool trigIsPossible = false;
    public int trigIsPossibleX = 0;
    public int trigIsPossibleY = 0;
    public int trigIsPossibleID = 0;
    public bool triged = false;
    public int trigX = 0;
    public int trigY = 0;
    public bool trigedb = false;
    public int trigXb = 0;
    public int trigYb = 0;
    public bool trigedc = false;
    public int trigXc = 0;
    public int trigYc = 0;
    public bool afficher_lancer = false;
    public bool lancer_a_Afficher = false;
    public int CountLeft = 0;
    public int CountLeftDL = 0;
    public bool choosen = false;
    public bool Saved = false;
    public int add = 0;
    public bool yutlist = false;
    public int computingPoints=0;
    public bool toUntrig = false;
    public int toUntrigX;
    public int toUntrigY;
    public int Jid = 1;
    public Vector2[,] CooListSansH = new Vector2[211, 211];
    public int[,,] pJpoueurs = new int[211, 211, 211];
    public bool Fived = false;
    public int turnsJ1 = 4;
    public int turnsJ2 = 4;
    public int[,] Pionturns = new int[10, 10];
    public bool[,] PionturnsPlus = new bool[10, 10];
    public bool[,] PionturnsMinus = new bool[10, 10];
    public bool[,] Pionraz = new bool[10, 10];
    public bool[,,] Pionlinked = new bool[10, 10, 10];
    public bool[,] Piontokill = new bool[10, 10];
    public (int, int)[,] PionFixed = new (int, int)[211, 211];
    public (int, int)[,] SaveTrigs = new (int, int)[211, 211];
    public int[,] SaveTurns = { { 0, 0, 0, 0, 0 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } };
    public int[] Turnleft = { 4, 4 };
    public int[] Turnwin = { 4, 4 };
    public bool autoL = false;
    public Toggle monToggle;
    public Toggle MoveY;
    public Toggle isClavierscreen;
    public Toggle IsIA;
    public Toggle IsIA1;
    public Slider LVLIA;
    public Slider AGRSTRAT;
    public Slider LVLIA2;
    public Slider AGRSTRAT2;
    bool randAlternative = false;
    bool randAlternativeO = false;
    bool randAF = false;
    bool CentreAlternative = false;
    public bool haveToComputing = true;
    bool coinsAlternative = false;
    bool y3Alternative = false;
    bool y4Alternative = false;
    public InputField csTextField;
    public int screenToInput;
    public GameObject scrnKb;
    public bool MY = false;
    public int uiState = 0;
    public TMP_InputField J1t;
    public TMP_InputField J3t;
    public TMP_InputField J5t;
    public TMP_InputField J7t;
    public TMP_InputField J9t;
    public TMP_InputField J11t;

    public TMP_InputField J2t;
    public TMP_InputField J4t;
    public TMP_InputField J6t;
    public TMP_InputField J8t;
    public TMP_InputField J10t;
    public TMP_InputField J12t;
    public GameObject Cheat;
    public TextMeshProUGUI Joueurs;
    private bool uiState3 = false;
    private bool uiStatestart = true;
    public string Jts = "Joueurs";
    //opéré dans sw juste switch public int lastJid=1;//si un changement s opère alors lancer des changemlents et après remetre switchname à false
    private int indexNameJ1 = 0;
    private int indexNameJ2 = -1;
    public bool switchNames = false;
    public string libNameText = "Joueur :";
    public int WinerId = 0;
    public bool RobotChoosen = false;
    public int RobotTimer = 0;
    public int RobotId = 0;
    public int RobotX = 0;
    public int RobotY = 0;
    public int RobotPion = 0;
    public int Indexcam = 0;
    public int[] iaLvl = { 50, 50, 50 };
    public int[] iaStrat = { 50, 50, 50 };
    public int[] iaAgr = { 50, 50, 50 };

    public bool iaProcessing = false;
    float sliderValueLvl;
    float sliderValueagr;
    float sliderValueLvl2;
    float sliderValueagr2;
    public List<PushUpData> listPlateau = new List<PushUpData>();
    public List<PushUpData> listePushUpsP = new List<PushUpData>();// pion advers neuds destinations de la plus strategique à la moins
    public List<PushUpData> listePushUpsPtrig = new List<PushUpData>();
    public List<PushUpData> listePushUpsPpoid = new List<PushUpData>();
    public List<PushUpData> listePushUpsPpoidplus = new List<PushUpData>();
    public List<PushUpData> listePushUpsO = new List<PushUpData>();
    public List<PushUpData> listePushUpsN = new List<PushUpData>();
    public List<PushUpData> listePushUpsD = new List<PushUpData>();
    //public int[,] SaveTurns = new int[10, 10]; 
    List<string> teamNam1 = new List<string>();
    List<string> teamNam2 = new List<string>();
    public TextMeshProUGUI[] textesBouton = new TextMeshProUGUI[40];
    public int[] computingPointsList = new int[40];

    // Start is called before the first frame update
    void setPlateau()
    {
        listPlateau.Add(new PushUpData(0, 0, 1));
        listPlateau.Add(new PushUpData(0, 0, 2));
        listPlateau.Add(new PushUpData(0, 0, 3));
        listPlateau.Add(new PushUpData(0, 0, 4));
        listPlateau.Add(new PushUpData(0, 0, 5));
        listPlateau.Add(new PushUpData(0, 0, 6));
        listPlateau.Add(new PushUpData(0, 0, 7));
        listPlateau.Add(new PushUpData(0, 0, 8));
        listPlateau.Add(new PushUpData(0, 0, 9));
        listPlateau.Add(new PushUpData(0, 0, 10));
        listPlateau.Add(new PushUpData(0, 0, 11));
        listPlateau.Add(new PushUpData(0, 0, 12));
        listPlateau.Add(new PushUpData(0, 0, 13));
        listPlateau.Add(new PushUpData(0, 0, 14));
        listPlateau.Add(new PushUpData(0, 0, 15));
        listPlateau.Add(new PushUpData(0, 0, 16));
        listPlateau.Add(new PushUpData(0, 0, 17));
        listPlateau.Add(new PushUpData(0, 0, 18));
        listPlateau.Add(new PushUpData(0, 0, 19));
        listPlateau.Add(new PushUpData(0, 0, 20));
        listPlateau.Add(new PushUpData(0, 3, 6));
        listPlateau.Add(new PushUpData(0, 3, 7));
        listPlateau.Add(new PushUpData(0, 3, 8));
        listPlateau.Add(new PushUpData(0, 3, 9));
        listPlateau.Add(new PushUpData(0, 3, 10));
        listPlateau.Add(new PushUpData(0, 4, 11));
        listPlateau.Add(new PushUpData(0, 4, 12));
        listPlateau.Add(new PushUpData(0, 4, 14));
        listPlateau.Add(new PushUpData(0, 4, 15));



    }
    void IsiaChg()
    {
        if (IsIA.isOn)
        {
            J2t.text = "Computer";
        }
        else { J2t.text = ""; }
    }
    void Isia1Chg()
    {
        if (IsIA1.isOn)
        {
            J1t.text = "Computer";
        }
        else { J1t.text = ""; }
    }
    void Start()
    {
        setyutsavetxt();
        startTime = Time.time;
        setPlateau();
        for (int i = 1; i <= 4; i++)
        {
            SaveTurns[1, i] = 1;
            SaveTurns[2, i] = 1;

        }
        IsIA.onValueChanged.AddListener(delegate { IsiaChg(); });
        IsIA1.onValueChanged.AddListener(delegate { Isia1Chg(); });
        monToggle.onValueChanged.AddListener(delegate { tog(); });
        InvokeRepeating("myUpdate", 0f, 0.1f);
        InvokeRepeating("myUpdate5", 0f, 0.5f);
    }
    // Fonction générique pour ajouter un push up à la liste
    void AjouterPushUp(List<PushUpData> liste, int x, int y, int joueur)
    {
        PushUpData pushUp = new PushUpData(x, y, joueur);
        liste.Add(pushUp);
    }
    public void tog()
    {
        autoL = monToggle.isOn;
    }
    public void togKB(int entry)
    {

        if (isClavierscreen.isOn)
        {
            screenToInput = entry;
            scrnKb.SetActive(true);
            if (entry == 1)
            {
                csTextField.text = J1t.text;
            }
            if (entry == 2)
            {
                csTextField.text = J2t.text;
            }
            if (entry == 3)
            {
                csTextField.text = J3t.text;
            }
            if (entry == 4)
            {
                csTextField.text = J4t.text;
            }
            if (entry == 5)
            {
                csTextField.text = J5t.text;
            }
            if (entry == 6)
            {
                csTextField.text = J6t.text;
            }
            if (entry == 7)
            {
                csTextField.text = J7t.text;
            }
            if (entry == 8)
            {
                csTextField.text = J8t.text;
            }
            if (entry == 9)
            {
                csTextField.text = J9t.text;
            }
            if (entry == 10)
            {
                csTextField.text = J10t.text;
            }
            if (entry == 11)
            {
                csTextField.text = J11t.text;
            }
            if (entry == 12)
            {
                csTextField.text = J12t.text;
            }

        }

    }
    private int ConvertB(int inty, int indy)
    {
        if (inty == 2) { inty = 3; } if (indy == 2) { indy = 3; }
        int Rvalue = 0;
        if (inty == 0 && indy == 4) { Rvalue = 12; }
        if (inty == 4 && indy == 0) { Rvalue = 33; }
        if (inty == 4 && indy == 3) { Rvalue = 34; }
        if (inty == 3 && indy == 4) { Rvalue = 20; }
        if (inty == 0 && indy == 3) { Rvalue = 10; }
        if (inty == 3 && indy == 0) { Rvalue = 17; }
        if (inty == indy) { Rvalue = 9; }

        return Rvalue;
    }
    private bool istrigable(int tx, int ty, int dx, int dy, int incount)
    {
        bool result = false;
        if (ty == 0 && dy == 3 && tx>14 && tx<21 ) {
            if (dx + incount + 4 == tx)
            {
            result = true;
            }
            //si sort du raccourci 3 qui passe de mo à 15 en ligne droite alors valider le trig
        }
        if (ty == 0 && tx == 20 && dy == 0 && dx == 1 && incount == -1)
        {
            result = true;
        }
        if (incount == -1) {// de 1 à 0
            if (tx == 20 && ty == 0 && dx == 1 && dy == 0) { result = true; }
        }
        if (ty == 0 && tx == 1 && dy == 4 && dx == 12 && incount == 5)
        {
            result = true;
        }
        if (dx == 14 && dy == 4 && ty == 0)
        {
            if (incount == 3)
            {
                if (tx == 1)
                {
                    result = true;
                }
            }
            if (incount == 4)
            {
                if (tx == 2)
                {
                    result = true;
                }
            }
            if (incount == 5)
            {
                if (tx == 3)
                {
                    result = true;
                }
            }
        }
        if (dx == 15 && dy == 4 && ty == 0)
        {
            if (incount == 2)
            {
                if (tx == 1)
                {
                    result = true;
                }
            }
            if (incount == 3)
            {
                if (tx == 2)
                {
                    result = true;
                }
            }
            if (incount == 4)
            {
                if (tx == 3)
                {
                    result = true;
                }
            }
            if (incount == 5)
            {
                if (tx == 4)
                {
                    result = true;
                }
            }
        }
        if (ty == 4 && dy == 0 && dx == 10) {
            if (tx - dx == incount)
            {
                result = true;
            }
        }
        if (dx + tx > 0 && ty == dy)
        {
            // change d endroit et même plan 
            if (tx - dx == incount)
            {
                result = true;
            }

        }
        if (incount == -1 && dy == 0 && (dx == 0 || dx == 20))
        {
            if (ty == 4 && tx == 15)
            {


                result = true;


            }
            if (ty == 0 && tx == 19)
            {


                result = true;


            }
        }




        //if (dy == 0 && (ty == 2 || ty == 3)) { dx += 4; ty = dy; }
        //if ((ty==3 || ty==2 && !done) && (dy==2 || dy == 3)) { ty = 0;dy = 0; }
        int combi = ConvertB(ty, dy);
        //bool done = false;// si converti remplacé par ty =dy nop car bug localisé
        // si resultat trouvé alors retour de ce dernier modifié
        if (ty == 0 && (dy == 3 || dy == 4))
        {
            if (tx - dx - 4 == incount)
            {
                //result = true;
            }
        }
        if (ty == 4 && dy == 3 && dx == 8)
        {
            if (tx - dx - 5 == incount)
            {
                result = true;
            }
        }
        if (incount == -1)
        {
            if (ty == 3 && dy == 4 && tx == 8 && dx == 14)
            {
                result = true;
            }
            if (ty == 4 && dy == 3 && dx == 8 && tx == 12)
            {
                result = true;
            }
            if (ty == 3 && dy == 0 && dx == 15 && tx == 10)
            {
                result = true;
            }
            if (ty == 4 && dy == 0 && dx == 20 && tx == 15)
            {
                result = true;
            }
            if (ty == 0 && dy == 4 && dx == 11 && tx == 10)
            {
                result = true;
            }
            if (ty == 0 && dy == 3 && dx == 6 && tx == 5)
            {
                result = true;
            }
            if (ty == 0 && dy == 3 && dx == 15 && tx == 10)
            {
                result = true;
            }
            if (ty == 0 && dy == 0 && dx == 1 && tx == 20)
            {
                result = true;
            }

        }

        if (incount == 5)
        {
            if (ty == 0 && dy == 3 && dx == 6 && tx == 20)
            {
                //result = true;
            }
            if (ty == 0 && dy == 3 && dx == 7 && tx == 1)
            {
                //result = true;
            }
            if (ty == 0 && dy == 3 && dx == 8 && tx == 2)
            {
                result = true;
            }

            if (ty == 4 && dy == 0 && dx == 5 && tx == 15)
            {
                // result = true;
            }
            if (ty == 4 && dy == 0 && dx == 4 && tx == 14)
            {
                // result = true;
            }
            // le 8 à la croisée des chemins

            if (ty == 3 && tx == 14 && 1 == 0)
            {
                if (incount == 1 && dy == 4 && dx == 12)
                {
                    result = true;
                }

                if (incount == 2 && dy == 4 && dx == 11)
                {
                    result = true;
                }

                if (incount == 3 && dy == 0 && dx == 10)
                {
                    result = true;
                }
                if (incount == 4 && dy == 0 && dx == 9)
                {
                    result = true;
                }
                if (incount == 5 && dy == 0 && dx == 8)
                {
                    result = true;
                }
            }
            // bifurquer?? pas dans les regles étudiéeqs


        }
        if (incount == 4)
        {
            if (ty == 0 && dy == 3 && dx == 7 && tx == 20)
            {
                //result = true;
            }
            if (ty == 0 && dy == 3 && dx == 8 && tx == 1)
            {
                //result = true;
            }

            if (ty == 4 && dy == 0 && dx == 5 && tx == 14)
            {
                // nop result = true;
            }


        }
        if (incount == 3)
        {
            if (ty == 0 && dy == 3 && dx == 8 && tx == 20)
            {
                result = true;
            }


        }
        //convertion par trig pour done=true
        if (ty == 3 && tx == 8 && dx < 13 && dx > 5)
        {
            // nop tx = 13; ty = 0; dy = 0;
        }
        // ici aproche de conversion de yn à y0
        if (dy == ty) { ty = 0; dy = 0; }
        if (dy == 0) {
            if ((ty == 3 && dy == 0) && (dx == 5))
            {
                //dy=0 : 
                // si dx<6 alors faire comme si se rien n etait ty=0;
                ty = 0;
            }
            if ((ty == 4 && dy == 0) && (dx == 5))
            {
                //dy=0 : 
                // si dx<6 alors faire comme si se rien n etait ty=0;
                ty = 0;
            }
            // /ici aproche de conversion de yn à y0
            int pt = dx + incount;//pion and trig line (same y tet ok) 
            if (pt > 20)
            {
                if (ty == dy)
                {// same dimension
                    if ((pt - 20) == tx)// 16
                    { result = true; }
                }
            }
            if (incount == -1)
            {
                if (ty == dy)
                {  // same dimension test ok 
                    if ((tx == 20 && dx == 1) || (tx == 19 && dx == 0))
                    { result = true;
                    }
                }
                if (ty == 4 && dy == 0 && tx == 15 && (dx == 0 || dx == 20))
                {
                    result = true;
                }
            }


            if (pt > 20) { dx = dx - 20; }

            if (ty == dy || (ty == 3 && dx == 5 && dy == 0) || (ty == 4 && dx == 15 && dy == 0))
            { ty = 0; }

            if (dx + tx > 0 && ty == dy)
            {
                // change d endroit et même plan 
                if (tx - dx == incount)
                {
                    result = true;
                }

            }
        }


        // after trig traitement grab traitement
        return result;
    }
    void istrigableb()
    {

        if ((SaveTurns[Jid, grabedPId] == 1 && (trigX == 20 && trigY == 0)))
        {// Si fin et tours 1 alors test des combi selon possibilité y4 et Y0
            //Debug.Log("SaveTurns[Jid, grabedPId] == 1 && (trigX == 20 && trigY == 0");
            if (CountLeft == -1 && grabedX == 1 && grabedY == 0) { trigIsPossible = true; }

            if (grabedY == 0)
            {
                //Debug.Log($"GRABED 0 << grabedX + CountLeft {grabedX + CountLeft} "); //Debug.Log($"EST >> {trigIsPossible}");
                if (grabedX + CountLeft > 19) { trigIsPossible = true; }
            }
            if (grabedY == 4)
            {  //Debug.Log("GRAB = 4");
                if (grabedX + CountLeft > 14) { trigIsPossible = true; }
            }
            if (grabedY == 3 && grabedX == 8 && CountLeft > 2) { trigIsPossible = true; }
        }
        // sortir nop grabedY == 3 ||
        if (trigY == 0 && (grabedY == 4))
        {

            if (trigX - grabedX - 4 == CountLeft)
            {
                trigIsPossible = true;
            }
        }
        // par le bas
        if (trigY == 4 && grabedX < 9 && (grabedY == 3))
        {

            if (trigX - grabedX - 5 == CountLeft)
            {
                // nop trigIsPossible = true;
            }
        }
        // le 8 du milieu y arriver
        if (grabedY == 3 && grabedX == 8)
        {
            if (CountLeft == 5)
            {
                if (trigX == 2 && trigY == 0)
                {
                    trigIsPossible = true;
                }
                if (trigX == 17 && trigY == 0)
                {
                    trigIsPossible = true;
                }

            }
            if (CountLeft == 4)
            {
                if (trigX == 1 && trigY == 0)
                {
                    trigIsPossible = true;
                }
                if (trigX == 16 && trigY == 0)
                {
                    trigIsPossible = true;
                }
            }

            if (CountLeft == 3)
            {
                if (trigX == 20 && trigY == 0)
                {
                    trigIsPossible = true;
                }
                if (trigX == 15 && trigY == 0)
                {
                    trigIsPossible = true;
                }
            }
            if (CountLeft == 2)
            {
                if (trigX == 15 && trigY == 4)
                {
                    trigIsPossible = true;
                }
            }
            if (CountLeft == 1)
            {
                if (trigX == 14 && trigY == 4)
                {
                    trigIsPossible = true;
                }
            }

        }
        // 8 on trig
        if (trigY == 3 && trigX == 8)
        {
            if (CountLeft == 5)
            {
                //8 0 nop
            }
            if (CountLeft == 4)
            {
                //9 0 nop
            }
            if (CountLeft == 3)
            {

                if (grabedX == 10 && grabedY == 0)
                {
                    trigIsPossible = true;
                }
            }
            if (CountLeft == 2)
            {
                if (grabedX == 11 && grabedY == 4)
                {
                    trigIsPossible = true;
                }

            }
            if (CountLeft == 1)
            {
                if (grabedX == 12 && grabedY == 4)
                {
                    trigIsPossible = true;
                }
            }
            if (CountLeft == -1)
            {
                if (grabedX == 14 && grabedY == 4)
                {
                    trigIsPossible = true;
                }
            }

        }
        // correctif sur bugs non trouvés!
        if (trigX == grabedX && trigY == grabedY) { trigIsPossible = false; }
        //if (trigX == 15 && grabedX==4  && trigY==4 && grabedY==0) { trigIsPossible = true; } se trouve sur choc
    }
    void isTrigableO()
    {
        if (!trigIsPossible && (grabedX != trigX && grabedY == trigY) || (trigY != grabedX))
        {
            //la fonction bug sortir -1 20 y0 pour tester?

            // same?



            trigIsPossible = istrigable(trigX, trigY, grabedX, grabedY, CountLeft);
            istrigableb();

            if (trigIsPossible) { trigIsPossibleX = trigX; trigIsPossibleY = trigY; }

        }
    }
    void turnL()
    {
        Turnleft[0] = 0;
        for (int i = 1; i <= 4; i++)
        {
            Turnleft[0] += Pionturns[1, i];
        }
        // turnsJ1 = Turnleft[0]; turnsJ2 = Turnleft[1];
        Turnleft[1] = 0;
        for (int i = 1; i <= 4; i++)
        {
            Turnleft[1] += Pionturns[2, i];
        }

    }

    //500ms
    private void Participants()
    {
        // bool PlusDeUn = false;
        //avant de traiter des index alors mettra à jour les list j1 et j2
        // vider les liste avant traitent teamNam1 et 2
        //teamNam1.Clear;        teamNam2.Clear; si non vide
        if (teamNam1.Count > 0)
        {
            teamNam1.Clear();

        }
        if (teamNam2.Count > 0)
        {
            teamNam2.Clear();

        }
        // on s occupe DE LA TEAM 1 et àpres du 2
        if (string.IsNullOrEmpty(J1t.text) || string.IsNullOrWhiteSpace(J1t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam1.Add(J1t.text);
        }
        if (string.IsNullOrEmpty(J3t.text) || string.IsNullOrWhiteSpace(J3t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam1.Add(J3t.text);
        }
        if (string.IsNullOrEmpty(J5t.text) || string.IsNullOrWhiteSpace(J5t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam1.Add(J5t.text);
        }
        if (string.IsNullOrEmpty(J7t.text) || string.IsNullOrWhiteSpace(J7t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam1.Add(J7t.text);
        }
        if (string.IsNullOrEmpty(J9t.text) || string.IsNullOrWhiteSpace(J9t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam1.Add(J9t.text);
        }
        if (string.IsNullOrEmpty(J11t.text) || string.IsNullOrWhiteSpace(J11t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam1.Add(J11t.text);
        }
        // remplir les listes selon les participents maListe.Add("Élément 1"); POUR Jé MAINTENANT
        if (string.IsNullOrEmpty(J2t.text) || string.IsNullOrWhiteSpace(J2t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam2.Add(J2t.text);
        }
        if (string.IsNullOrEmpty(J4t.text) || string.IsNullOrWhiteSpace(J4t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam2.Add(J4t.text);
        }
        if (string.IsNullOrEmpty(J6t.text) || string.IsNullOrWhiteSpace(J6t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam2.Add(J6t.text);
        }
        if (string.IsNullOrEmpty(J8t.text) || string.IsNullOrWhiteSpace(J8t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam2.Add(J8t.text);
        }
        if (string.IsNullOrEmpty(J10t.text) || string.IsNullOrWhiteSpace(J10t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam2.Add(J10t.text);
            //cheat activated?
            if (J10t.text == "CheatDebug!")
            {
                Cheat.SetActive(true);

            }
            else
            {
                Cheat.SetActive(false);
            }
        }
        if (string.IsNullOrEmpty(J12t.text) || string.IsNullOrWhiteSpace(J12t.text))
        {
            //vide
        }
        else
        {
            // un nom de plus dans la liste.*
            teamNam2.Add(J12t.text);
        }
        //index et lib
        if (teamNam1.Count > 1 || teamNam2.Count > 1)
        {

            libNameText = "Equipe : ";
        }
        else
        {
            libNameText = "Joueur : ";
        }
        if (1 == 2)
        {
            if (teamNam1.Count > 0)
            {
                // Convertir la liste en une seule chaîne avec des espaces entre les éléments.

                string concatenatedString = " team 1: ";

                foreach (var robota in teamNam1)
                {
                    concatenatedString += robota + " ";
                }

                // Afficher la chaîne résultante dans la console Unity.
                ///Debug.Log(concatenatedString);
            }
            if (teamNam2.Count > 0)
            {
                // Convertir la liste en une seule chaîne avec des espaces entre les éléments.

                string concatenatedStringB = " team 2: ";

                foreach (var robota in teamNam2)
                {
                    concatenatedStringB += robota + " ";
                }
                // Afficher la chaîne résultante dans la console Unity.
                //Debug.Log(concatenatedStringB);
            }
        }

        //Debug.Log(libNameText+"Champ  teamNam1.Count, valeur : " + teamNam1.Count.ToString());
        // index maintenant
        // metre à jour le libilé au dessus des nom si une des deux equipes comportent plus d'un membre%.

        if (switchNames) {
            if (Jid == 1)
            {
                indexNameJ1 += 1;
                if (indexNameJ1 > teamNam1.Count - 1) { indexNameJ1 = 0; }
            }
            else
            {
                indexNameJ2 += 1;
                if (indexNameJ2 > teamNam2.Count - 1) { indexNameJ2 = 0; }
            }


            switchNames = false;
        }



        if (Jid == 1)
        {
            if (teamNam1.Count > 0) { Jts = teamNam1[indexNameJ1]; } else { Jts = ""; }

        }
        else

        {
            if (teamNam2.Count > 0) { Jts = teamNam2[indexNameJ2]; } else { Jts = ""; }

        }
        Joueurs.text = Jts;

    }
    private int other(int inID)
    {
        int result = 0;
        if (inID == 1) { result = 2; } else { result = 1; }
        return result;
    }
    private void listOthers()
    {

        for (int i = 1; i <= 4; i++)
        {
            if (SaveTurns[other(Jid), i] == 1 && (pJpoueurs[i, Jid, 0] != 0 && pJpoueurs[i, Jid, 1] != 0)) {
                AjouterPushUp(listePushUpsO, pJpoueurs[i, other(Jid), 0], pJpoueurs[i, other(Jid), 1], other(Jid)); }
        }
        for (int i = 1; i <= 4; i++)
        {
            if (SaveTurns[Jid, i] == 1 && (pJpoueurs[i, Jid, 0] != 0 && pJpoueurs[i, Jid, 1] != 0))
            {
                AjouterPushUp(listePushUpsP, pJpoueurs[i, Jid, 0], pJpoueurs[i, Jid, 1], other(Jid));
            }
        }


    }
    void RobotDoing()
    {
        RobotTimer++;
        if (RobotTimer > 4000) { RobotChoosen = false; }

    }
    void AleaSup(int pourcentage)
    {
        int tot = listePushUpsPpoid.Count;
        int iterations = 0;


        do
        {
            foreach (var robot in listePushUpsPpoid)
            {
                iterations++;

                if (iterations <= pourcentage)
                {
                    if (Random.Range(1, 100) > 50)
                    {
                        iterations++;
                        listePushUpsPpoid.Remove(robot);
                    }
                }
            }
        } while (iterations < pourcentage);
    }
    void robotStrat()
    {

        //il faut 3 variables une est le niveat de l ia int iaLvl et les autre iaStrat iaAgr
        // pour les deux process AleaSup(int pourcentage) selon le niveau des deux fonction robotAgr et robotStrat
        //Strategie

        foreach (var robot in listePushUpsPpoid)
        {
            foreach (var robota in listePushUpsP)
            {

                if (randAlternative)
                {

                    if (robot.p != robota.p && robot.x == robota.x && robot.y == robota.y)
                    {
                        // Calculez le temps écoulé depuis le début de l'événement
                        //float elapsedTime = Time.time - startTime;

                        // Convertissez le temps en minutes et secondes
                        //int minutes = Mathf.FloorToInt(elapsedTime / 60f);
                        //int seconds = Mathf.FloorToInt(elapsedTime % 60f);

                        // Affichez le temps dans la console Unity
                        //Debug.Log($"Temps écoulé : {minutes:00}:{seconds:00}");
                        //Debug.Log($"alternative strat x {robot.x} et y {robot.y} ialvl {iaLvl[Jid]} Temps écoulé : {minutes:00}:{seconds:00}");
                        //AleaSup(iaLvl);
                        for (int i = 1; i <= iaLvl[Jid] * iaStrat[Jid]; i++)
                        {
                            listePushUpsPpoidplus.Add(new PushUpData(robot.p, robot.y, robot.x));
                        }
                    }



                }


            }
        }
    }
    void robotAgr()
    {

        //il faut 3 variables une est le niveat de l ia int iaLvl et les autre iaStrat iaAgr
        // pour les deux process AleaSup(int pourcentage) selon le niveau des deux fonction robotAgr et robotStrat

        //agressivité
        foreach (var robot in listePushUpsPpoid)
        {
            foreach (var robota in listePushUpsO)
            {

                if (randAlternativeO)
                {
                    if (robot.x == robota.x && robot.y == robota.y)
                    {
                        //AleaSup(iaLvl);
                        // Calculez le temps écoulé depuis le début de l'événement
                        //float elapsedTime = Time.time - startTime;

                        // Convertissez le temps en minutes et secondes
                        //int minutes = Mathf.FloorToInt(elapsedTime / 60f);
                        //int seconds = Mathf.FloorToInt(elapsedTime % 60f);

                        // Affichez le temps dans la console Unity
                        //Debug.Log($"Temps écoulé : {minutes:00}:{seconds:00}");
                        //Debug.Log($"alternative agr x {robot.x} et y {robot.y} ialvl {iaLvl[Jid]} Temps écoulé : {minutes:00}:{seconds:00}");
                        for (int i = 1; i <= iaLvl[Jid] * iaAgr[Jid]; i++)
                        {
                            listePushUpsPpoidplus.Add(new PushUpData(robot.p, robot.y, robot.x));
                        }
                    }




                }








            }
        }
    }
    void mieux()
    {

        //il faut 3 variables une est le niveat de l ia int iaLvl et les autre iaStrat iaAgr
        // pour les deux process AleaSup(int pourcentage) selon le niveau des deux fonction robotAgr et robotStrat

        //agressivité
        foreach (var robot in listePushUpsPpoid)
        {

            if (randAF)
            {

                listePushUpsPpoidplus.Add(new PushUpData(robot.p, robot.y, robot.x));
            }








            if (iaLvl[Jid] < 5)
            {
                for (int i = 1; i <= 11 - iaLvl[Jid]; i++)
                {
                    listePushUpsPpoidplus.Add(new PushUpData(robot.p, robot.y, robot.x));
                }
            }
            if (CentreAlternative)
            {

                if (robot.x == 8 && robot.y == 3) { listePushUpsPpoidplus.Add(new PushUpData(robot.p, robot.y, robot.x)); }
            }
            if (coinsAlternative)
            {

                if (robot.y == 0 && (robot.x == 5 || robot.x == 10)) { listePushUpsPpoidplus.Add(new PushUpData(robot.p, robot.y, robot.x)); }

            }
            if (y4Alternative)
            {

                if (robot.y == 4) { listePushUpsPpoidplus.Add(new PushUpData(robot.p, robot.y, robot.x)); }
            }

            if (y3Alternative)
            {

                if (robot.y == 3) { listePushUpsPpoidplus.Add(new PushUpData(robot.p, robot.y, robot.x)); }
            }




        }




    }

    void randalt()
    {
        
        //Debug.Log("Randalt ok < poidia ok < trig ok < pushs robot computing ok! ");
        int Depart = 0;
        foreach (var robot in listePushUpsPpoid)
        {
            //bool randAlternative = false;Debug.Log("centre"); 
            //bool CentreAlternative = false;Debug.Log("coins");
            //bool coinsAlternative = false;Debug.Log("y3");
            //bool y3Alternative = false;Debug.Log("y4");
            //bool y4Alternative = false;
            if (pJpoueurs[robot.p, Jid, 0]==0 && pJpoueurs[robot.p, Jid, 1]==0) { Depart++; }
            if (robot.x == 8 && robot.y == 3) { CentreAlternative = true; }
            if (robot.y == 0 && (robot.x == 5 || robot.x == 10)) { coinsAlternative = true; }
            if (robot.y == 3) { y3Alternative = true; }
            if (robot.y == 4) { y4Alternative = true; }
            foreach (var robota in listePushUpsO)
            {
                if (robot.x == robota.x && robot.y == robota.y)
                {
                    computingPoints = 1000;
                    randAlternativeO = true;
                }
            }
            foreach (var robotb in listePushUpsP)
            {
                if (robot.p != robotb.p && robot.x == robotb.x && robot.y == robotb.y)
                {
                    computingPoints = 100;
                    randAlternative = true;
                }
            }
        }
        //Debug.Log(">randAlternative: " + randAlternative);
        //Debug.Log(">randAlternativeO: " + randAlternativeO);
        //Debug.Log(">CentreAlternative: " + CentreAlternative);
        //Debug.Log(">coinsAlternative: " + coinsAlternative);
        //Debug.Log(">y3Alternative: " + y3Alternative);
        //Debug.Log(">y4Alternative: " + y4Alternative);
        if ( randAlternative ||  randAlternativeO || CentreAlternative || coinsAlternative || y3Alternative || y4Alternative)
        {

            randAF = false;
        }
      
        if (randAlternative || randAlternativeO)
        {
            randAF = false;
            CentreAlternative = false; coinsAlternative = false; y3Alternative = false; y4Alternative = false;
        }
        if (!randAlternative && !randAlternativeO)
        {

            if (CentreAlternative) { coinsAlternative = false; y3Alternative = false; y4Alternative = false; computingPoints = 10; }
            else
            {
                if (coinsAlternative) { coinsAlternative = false; y3Alternative = false; y4Alternative = false; computingPoints = 10; }
                else
                {

                    if (y4Alternative) { y3Alternative = false; computingPoints = 1; }
                    if (Depart>0) { randAF= true;}
                }
            }
        }
        if (!randAlternative && !randAlternativeO && !CentreAlternative && !coinsAlternative && !y3Alternative && !y4Alternative)
        {

            randAF = true;
        }
        // Concaténer les états de chaque booléen et l'heure actuelle dans une chaîne
        //string debugMessage = string.Format("rand af : {7} randAlternative: {0}, randAlternativeO: {1}, CentreAlternative: {2}, coinsAlternative: {3}, y3Alternative: {4}, y4Alternative: {5}, Heure actuelle: {6}",
          //                                  randAlternative, randAlternativeO, CentreAlternative, coinsAlternative, y3Alternative, y4Alternative, Time.time.ToString("HH:mm:ss"),randAF);

        // Afficher la chaîne complète dans la console Unity
        //Debug.Log(debugMessage);
    }

    
  void poidIA() {
        //Debug.Log("poidia ok<trig ok<pushs robot computing ok! ");
        //il faut 3 variables une est le niveat de l ia int iaLvl et les autre iaStrat iaAgr
        // pour les deux process AleaSup(int pourcentage) selon le niveau des deux fonction robotAgr et robotStrat
        randalt();
        
           // Debug.Log(" <a< rob strat ok < robagr ok < Randalt ok < poidia ok < trig ok < pushs robot computing ok! ");
            robotAgr();
        
      
            //Debug.Log(" <s< rob strat ok < robagr ok < Randalt ok < poidia ok < trig ok < pushs robot computing ok! ");
            robotStrat();
        
        mieux();
       
        
        
            
        //Debug.Log("Contenu de listePushUpsPpoidplus :");
        //foreach (var robot in listePushUpsPpoidplus)
        //{
        //    Debug.Log($"x: {robot.x}, y: {robot.y}, p: {robot.p}");
        //}
        foreach (var robot in listePushUpsPpoidplus)
        {
listePushUpsPtrig.Add(new PushUpData(robot.p, robot.y, robot.x));
        }
            
    }
    void RobotComputing()
    {
        listePushUpsPtrig.Clear();
        listePushUpsPpoid.Clear();
        listePushUpsPpoidplus.Clear();

        int pionIn = 0;
        int iter = 0;
        bool inchoose = false;
        int saveX = grabedX;
        int saveY = grabedY;
        int Coins = 1;
        int troupeau = 1;
        foreach (var robot in listePushUpsP)
        {
            //Debug.Log($"Robot - x: {robot.x}, y: {robot.y}, p: {robot.p} iter : {iter}");
            foreach (var plat in listPlateau)
            {
                //Debug.Log($"Robot - x: {robot.x}, y: {robot.y}, p: {robot.p} iter : {iter}");
                //Debug.Log($"Plat - x: {plat.x}, y: {plat.y}, p: {plat.p}");
                iter++;
                trigX = plat.x;
                trigY = plat.y;
                grabedX = robot.x;
                grabedY = robot.y;
                //RobotPion = iter;
                isTrigableO();
                //Debug.Log("trig ok<pushs robot computing ok! ");
                if (trigIsPossible && !RobotChoosen)
                {
                   
                    if ((trigX ==5 && trigY ==0) || (trigX ==10 && trigY ==0) || (trigX ==8 && trigY ==3) )
                    { Coins = 1*(trigY*3+1); }
                    troupeau = 30 - trigY * 2 - pJpoueurs[robot.p, Jid, 0];//sortir ceux à la traine
                    for (int i = 1; i <=Coins*Coins* troupeau; i++)
                    {
                    listePushUpsPpoid.Add(new PushUpData(robot.p, trigY, trigX));
                    }
                    Coins = 1;
                    troupeau = 1;
                    //Debug.Log($"Added to listePushUpsPtrig: x={robot.x}, y={robot.y}, p={robot.p}");
                }
                trigIsPossible = false;


            }
           
        }
        grabedX = saveX;
        grabedY = saveY;
        poidIA();
        int randomChoicei = 0;
        int randomChoice = 0; // Initialiser à une valeur qui ne peut pas être choisie au hasard
        bool aleaChoosen = false;
       
        randomChoice = Random.Range(1, listePushUpsPtrig.Count);
       //Debug.Log($"chxi : {randomChoicei}, qte: {listePushUpsPtrig.Count}, choix: {randomChoice} iter : {iter}");
            foreach (var robot in listePushUpsPtrig)
            {
            randomChoicei++;

            //Debug.Log($"Robot - x: {robot.x}, y: {robot.y}, p: {robot.p} iter : {iter}");
            if (randomChoicei == randomChoice)
                {
                
                trigX = robot.x;
                trigY = robot.y;
                grabedY = pJpoueurs[robot.p, Jid, 1];
                grabedX= pJpoueurs[robot.p, Jid, 0];
                trigIsPossibleX = trigX; trigIsPossibleY = trigY;
                   RobotChoosen = true;
                    RobotX = trigX; RobotY = trigY; 
                RobotPion = robot.p; RobotId = Jid;
                    aleaChoosen = true;
                trigIsPossible = true;
                grabed = true;
                if (1 == 2)
                {
        // /
                // Calculez le temps écoulé depuis le début de l'événement
                float elapsedTime = Time.time - startTime;

                // Convertissez le temps en minutes et secondes
                int minutes = Mathf.FloorToInt(elapsedTime / 60f);
                int seconds = Mathf.FloorToInt(elapsedTime % 60f);

                // Affichez le temps dans la console Unity
                //Debug.Log($"Temps écoulé : {minutes:00}:{seconds:00}");
                // /
                Debug.Log($" de x{grabedX} y {grabedY}Temps écoulé : {minutes:00}:{seconds:00} Choix Count left: {CountLeft}>> x: {robot.x}, y: {robot.y}, p: {robot.p}");
           
                }
        
            }
          

            }


        iaProcessing = false;
    }
    void fillPushs()
    {
       // Qui est sur le plateau?
        listePushUpsP.Clear();
        listePushUpsO.Clear();
        randAlternative = false;
            randAlternativeO = false;
        CentreAlternative = false;
        coinsAlternative = false;
        y3Alternative = false;
        y4Alternative = false;
        randAF = true;




        for (int i = 1; i <= 4; i++)
        {

            if (SaveTurns[1, i] != 0)
            {
               
                
                    if (Jid == 1)
                    {
                        listePushUpsP.Add(new PushUpData(i, pJpoueurs[i, 1, 1], pJpoueurs[i, 1, 0]));
                    }
                    else
                    {
                        listePushUpsO.Add(new PushUpData(i, pJpoueurs[i, 1, 1], pJpoueurs[i, 1, 0]));
                    }
                

            }
            if (SaveTurns[2, i] != 0)
            {


                if (Jid == 2)
                {//2 1 1 2
                    listePushUpsP.Add(new PushUpData(i, pJpoueurs[i, 2, 1], pJpoueurs[i, 2, 0]));
                }
                else
                {
                    listePushUpsO.Add(new PushUpData(i, pJpoueurs[i, 2, 1], pJpoueurs[i, 2, 0]));
                }

            }

        }
        
       
       

        
    }
    void myUpdate5()
    {
       
   
    
        sliderValueLvl = LVLIA.value;
        iaLvl[1] = 1+Mathf.RoundToInt(sliderValueLvl*9);
        sliderValueagr = AGRSTRAT.value;
        iaAgr[1] = 1+Mathf.RoundToInt(sliderValueagr*9);
        iaStrat[1]  = 10- iaAgr[1]+1;

        sliderValueLvl2 = LVLIA2.value;
        iaLvl[2] = 1 + Mathf.RoundToInt(sliderValueLvl2 * 9);
        sliderValueagr2 = AGRSTRAT2.value;
        iaAgr[2] = 1 + Mathf.RoundToInt(sliderValueagr2 * 9);
        iaStrat[2] = 10 - iaAgr[2]+1;

        if (Jts == "Computer") { monToggle.isOn=true;  RobotTimer++; if (RobotTimer >= 50) { haveToComputing = true; } }
        if (RobotChoosen) { RobotTimer = 0; RobotDoing(); }
        if (haveToComputing && Indexcam>2 && !iaProcessing && Jts == "Computer" && !RobotChoosen && CountLeft != -9 && CountLeft != 0 && Indexcam != 1)
        {
            haveToComputing = false;
            RobotTimer = 0;
            iaProcessing = true;
            fillPushs(); //Debug.Log("pushs");
            //RobotPion = 44444;
            RobotComputing(); //Debug.Log("<pushs robot computing ok! ");
            //listOthers(); Fonction à supprimer??

        }
        if (WinerId == 0 )
        {
            int winCount = 0;
           if (Indexcam > 2)
            {

                for (int i = 1; i <= 4; i++)
                {

                    if (SaveTurns[1, i] != 0)
                    {
                        winCount += SaveTurns[1, i];


                    }


                }
                turnsJ1 = winCount;
                if (winCount == 0) { WinerId = 1; }
                winCount = 0;

                for (int i = 1; i <= 4; i++)
                {

                    if (SaveTurns[2, i] != 0)
                    {
                        winCount += SaveTurns[2, i];


                    }

                }
                //foreach (var pushUpData in listePushUpsP) { Debug.Log($"x: {pushUpData.x}, y: {pushUpData.y}, p: {pushUpData.p}");            }

                turnsJ2 = winCount;
                if (winCount == 0) { WinerId = 2; }
            }
            
           
            if (WinerId != 0)
            {
                for (int i = 1; i <= 4; i++)
                {
                    SaveTurns[1, i] = 1;
                    SaveTurns[2, i] = 1;

                }    
            }

        }
        else
        {
            if (!uiState3)
            {
                win();
                uiStateIII();
            }
          
        }
        MY =MoveY.isOn;
        Participants();
       
        if (uiState == -1)
        {
            for (int i = 1; i <= 4; i++)
            {
                Pionraz[1, i] = true;
                Pionraz[2, i] = true;
            }
            uiState =0;
        }
        turnL();
    }
    // Update is called once per 100ms
    
    void myUpdate()
    {
        //public Toggle isClavierscreen;
        //public InputField csTextField;
        //public int screenToInput;
        //public GameObject scrnKb;
        if (isClavierscreen.isOn && scrnKb.activeSelf)
        {
            if (screenToInput ==1)
            {
                J1t.text= csTextField.text;
            }
            if (screenToInput == 2)
            {
                J2t.text = csTextField.text;
            }
            if (screenToInput == 3)
            {
                J3t.text = csTextField.text;
            }
            if (screenToInput == 4)
            {
                J4t.text = csTextField.text;
            }
            if (screenToInput == 5)
            {
                J5t.text = csTextField.text;
            }
            if (screenToInput == 6)
            {
                J6t.text = csTextField.text;
            }
            if (screenToInput == 7)
            {
                J7t.text = csTextField.text;
            }
            if (screenToInput == 8)
            {
                J8t.text = csTextField.text;
            }
            if (screenToInput == 9)
            {
                J9t.text = csTextField.text;
            }
            if (screenToInput == 10)
            {
                J10t.text = csTextField.text;
            }
            if (screenToInput == 11)
            {
                J11t.text = csTextField.text;
            }
            if (screenToInput == 12)
            {
                J12t.text = csTextField.text;
            }
        } 
       
        isTrigableO();
        if (trigedb && !triged)
        {
            trigedb = false;
            triged = true;
            trigX = trigXb;
            trigXb = 0;
            trigY = trigYb;
            trigYb = 0;
        }
        if (trigedc && !trigedb && !triged)
        {
            trigedc = false;
            trigedb = true;
            trigXb = trigXc;
            trigXc = 0;
            trigYb = trigYc;
            trigYc = 0;
        }
        if (!grabed)
        {
    triged = false;
    trigX = 0;
    trigY = 0;
    trigedb = false;
    trigXb = 0;
    trigYb = 0;
    trigedc = false;
    trigXc = 0;
    trigYc = 0;
    }
    }
   
    // Update is called once per frame
    void Update()
    {
          }
    public void uiStateI()
    {
        uiState = 1;
    }
    public void uiStateII()
    {
        uiState = 2;
    }
    public void uiStateIII()
    {
        uiState = 3;
        uiState3 = !uiState3;
    }
    public void uiState0()
    {
        uiState = -1;
    }
    public void uiStateStart()
    {
        uiState = 4;
        uiStatestart = false;
    }
    public void Raznames()
    {

        J1t.text = ""; J2t.text = ""; J3t.text = ""; J4t.text = ""; J5t.text = ""; J6t.text = "";
        J7t.text = ""; J8t.text = ""; J9t.text = ""; J10t.text = ""; J11t.text = ""; J12t.text = "";
    }
    public void win()
    {
       
        // Mettez à jour le texte du TextMesh avec le nom du joueur  
        WinTxt.text = libNameText + WinerId.ToString();
    }
    bool YutVide()
    {
        bool result = false;
        add = 0;
        for (int i = 0; i < textesBouton.Length; i++)
        {
            // Vérifiez si la position actuelle est nulle ou satisfait une certaine condition
            if (textesBouton[i].text != "")
            {

                 add++;
            }
            else
            {
              
            }
        }
        if (add-1 != 0) { result = true; }
        // Utilisez la méthode All pour vérifier si toutes les valeurs sont fausses et vides ( texte == null || !texte.enabled) &&
        return result;
    }
    public void OnBoutonClicYut(int inval)
    {
        CountLeftDL = inval;
        //Debug.LogError("conversion du texte en int.");
        
       // add--;
        //GetComponentInChildren<TextMeshProUGUI>().text = "";
        yutlist = YutVide();
    }
    
    public void SaveCountLeft(int inval)
    {
        //add++;
        for (int i = 0; i < textesBouton.Length; i++)
        {
            // Vérifiez si la position actuelle est nulle ou satisfait une certaine condition
            if (textesBouton[i] == null || textesBouton[i].text == "")
            {
                // Placez la valeur dans la première position disponible
                // (vous pouvez également avoir une logique spécifique ici pour déterminer si la position est "disponible")
                textesBouton[i].text = inval.ToString();

                // Sortez de la boucle après avoir sauvegardé la valeur
                return;
            }
        }
       
        // Si toutes les positions sont occupées, vous pouvez gérer cela d'une manière appropriée.
        Debug.LogWarning("Aucune place disponible dans le tableau pour sauvegarder la valeur.");
    }
    void setyutsavetxt()
    {
        for (int i = 0; i < textesBouton.Length; i++)
        {
            
            textesBouton[i].text = "";
            
        }
    }
    //computingPoints = 100; computingPointslist, le but est de tester les combi avec plus de potentialité pour le computer afin qu'il choisisse la bonne combinéson, la plus forte en premier
}
