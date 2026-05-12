using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickObject : MonoBehaviour
{
    public GameObject infoPanel;

   
    public TMP_Text descriptionText;

    public Image displayImage;     // UI Image in Canvas
    public Sprite objectSprite;    // Image for this object

    public string objectTitle;

    [TextArea]
    public string objectDescription;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = infoPanel.GetComponent<CanvasGroup>();

        HidePanel();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    ShowPanel();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HidePanel();
        }
    }

    public void ShowPanel()
    {
        infoPanel.SetActive(true);

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

      
        descriptionText.text = objectDescription;

        displayImage.sprite = objectSprite;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HidePanel()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        infoPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}