using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlideHide : MonoBehaviour
{
    public TextMeshProUGUI texteBouton;
    public ScrollRect scrollRect;
    public Scrollbar verticalScrollbar;

    void Start()
    {
        if (texteBouton == null || verticalScrollbar == null)
        {
            Debug.LogError("Assurez-vous d'assigner le TextMeshProUGUI et le ScrollRect dans l'éditeur Unity.");
            return;
        }

        // Désactivez la barre de défilement horizontale si le texte initial est vide
        VerifierEtDesactiverScrollbar();
        InvokeRepeating("MyUpdate", 0.0f, 0.5f);
    }

    void MyUpdate()
    {
        // Vérifiez et désactivez la barre de défilement horizontale à chaque mise à jour si nécessaire
        VerifierEtDesactiverScrollbar();
    }
    void ForceScrollRectToZero()
    {
        if (scrollRect != null)
        {
            // Forcez la valeur du ScrollRect à 0
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }
    void VerifierEtDesactiverScrollbar()
    {
        
       
        // Vérifiez si le texte du bouton est vide ou null
        if (string.IsNullOrEmpty(texteBouton.text))
        {
            // Si le texte est vide, masquez le bouton
            ForceScrollRectToZero();
            verticalScrollbar.handleRect.gameObject.SetActive(false);
        }
        else
        {
            // Sinon, assurez-vous que le bouton est visible
            
            verticalScrollbar.handleRect.gameObject.SetActive(true);
        }
        
    }
}
