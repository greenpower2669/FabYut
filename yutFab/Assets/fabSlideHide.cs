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
            Debug.LogError("Assurez-vous d'assigner le TextMeshProUGUI et le ScrollRect dans l'�diteur Unity.");
            return;
        }

        // D�sactivez la barre de d�filement horizontale si le texte initial est vide
        VerifierEtDesactiverScrollbar();
        InvokeRepeating("MyUpdate", 0.0f, 0.5f);
    }

    void MyUpdate()
    {
        // V�rifiez et d�sactivez la barre de d�filement horizontale � chaque mise � jour si n�cessaire
        VerifierEtDesactiverScrollbar();
    }
    void ForceScrollRectToZero()
    {
        if (scrollRect != null)
        {
            // Forcez la valeur du ScrollRect � 0
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }
    void VerifierEtDesactiverScrollbar()
    {
        
       
        // V�rifiez si le texte du bouton est vide ou null
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
