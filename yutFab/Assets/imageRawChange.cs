using UnityEngine;

public class ImageResizer : MonoBehaviour
{
    // Rendez les variables publiques pour y accéder depuis l'éditeur Unity
    public Vector2 initialSize;
    public bool isResizing = false;
    public Vector2 initialPosition;
    public float scaleFactor = 5f; // Ajoutez cette ligne pour le facteur de zoom

    void Start()
    {
        // Sauvegarder la taille initiale de l'image
        initialSize = GetComponent<RectTransform>().sizeDelta;
        // Sauvegarder la position initiale de l'image
        initialPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    void Update()
    {
        if (Input.touchSupported)
        {
            HandleTouchInput();
        }
        else
        {
            HandleMouseInput();
        }
    }

    void HandleTouchInput()
    {
        // Vérifier s'il y a des touches sur l'écran
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Supposons que nous utilisons le premier toucher détecté

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Vérifier si le toucher a commencé sur l'image
                    if (IsTouchOnImage(touch.position))
                    {
                        isResizing = true;
                        CenterImage();
                    }
                    break;

                case TouchPhase.Moved:
                    // L'utilisateur continue d'appuyer, ajustez la taille de l'image
                    if (isResizing)
                    {
                        ResizeImage();
                        CenterImage();
                    }
                    break;

                case TouchPhase.Ended:
                    // L'utilisateur a relâché, arrêtez le redimensionnement
                    isResizing = false;

                    // Réinitialiser la taille de l'image à sa taille initiale
                    ResetImageSize();
                    ResetImagePosition();
                    break;
            }
        }
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Vérifier si le clic de la souris a commencé sur l'image
            if (IsMouseOnImage(Input.mousePosition))
            {
                isResizing = true;
                CenterImage();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // L'utilisateur a relâché le clic, arrêtez le redimensionnement
            isResizing = false;

            // Réinitialiser la taille de l'image à sa taille initiale
            ResetImageSize();
            ResetImagePosition();
        }

        // Si l'utilisateur continue de maintenir le clic, ajustez la taille de l'image
        if (isResizing && Input.GetMouseButton(0))
        {
            ResizeImage();
            CenterImage();
        }
    }

    bool IsTouchOnImage(Vector2 touchPosition)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 localPoint;

        // Convertir la position du toucher en espace local de l'image
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touchPosition, null, out localPoint);

        // Vérifier si la position locale est à l'intérieur du rectangle de l'image
        return rectTransform.rect.Contains(localPoint);
    }

    bool IsMouseOnImage(Vector3 mousePosition)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 localPoint;

        // Convertir la position de la souris en espace local de l'image
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePosition, null, out localPoint);

        // Vérifier si la position locale est à l'intérieur du rectangle de l'image
        return rectTransform.rect.Contains(localPoint);
    }

    void ResizeImage()
    {
        Vector2 newSize = initialSize * scaleFactor;
        GetComponent<RectTransform>().sizeDelta = newSize;
    }

    void ResetImageSize()
    {
        GetComponent<RectTransform>().sizeDelta = initialSize;
    }

    void CenterImage()
    { 
        RectTransform rectTransform = GetComponent<RectTransform>();
        float moitieLargeur = rectTransform.rect.width / 2f;
       
        Vector2 centerPosition = new Vector2(0f + moitieLargeur, 0f);
        rectTransform.anchoredPosition = centerPosition;
    }

    void ResetImagePosition()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = initialPosition;
    }
}
