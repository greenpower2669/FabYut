using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestionBouton : MonoBehaviour
{
    //ne change pas alos garder en mémoire
    GameObject objetAChercher;
    Globals globalsScript;
    void Start()
    {
        // ne change pas alors rester en mémoire
        GameObject objetAChercher = GameObject.FindWithTag("Globals");
        globalsScript = objetAChercher.GetComponent<Globals>();
        // Vérifiez le texte initial du bouton au démarrage
        VerifierTexteBouton();

        // Lance la méthode MyUpdate toutes les 0.5 secondes (500 ms)
        InvokeRepeating("MyUpdate", 0.0f, 0.5f);
    }

    void MyUpdate()
    {
        // Mettez à jour votre logique ici
        //Debug.Log("Mise à jour toutes les 500 ms");
        VerifierTexteBouton();
    }

    void VerifierTexteBouton()
    {
        // Obtenez les composants nécessaires directement à partir de l'objet auquel ce script est attaché
        TextMeshProUGUI texteBouton = GetComponentInChildren<TextMeshProUGUI>();
        Button bouton = GetComponent<Button>();

        // Vérifiez si le texte du bouton est vide ou null
        if (string.IsNullOrEmpty(texteBouton.text))
        {
            // Si le texte est vide, masquez le bouton
            bouton.gameObject.SetActive(false);
        }
        else
        {
            // Sinon, assurez-vous que le bouton est visible
            bouton.gameObject.SetActive(true);
        }
    }
    public void onClickYut()
    {
        
       
        // Convertissez le contenu text en int et affectez-le à CountLeft dans le script Globals
        if (int.TryParse(GetComponentInChildren<TextMeshProUGUI>().text, out int contenuConverti))
        {
            globalsScript.OnBoutonClicYut(contenuConverti);
            GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        else
        {
            Debug.LogError("Erreur de conversion du texte en int.");
        }
        

    }
}


