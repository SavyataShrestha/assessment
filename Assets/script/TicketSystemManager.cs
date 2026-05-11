using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TicketSystemManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject ticketpannel;
    public GameObject buttonsPanel;
    public GameObject summaryPanel;

    [Header("Text Displays")]
    public TextMeshProUGUI adultCountText;
    public TextMeshProUGUI childCountText;
    public TextMeshProUGUI totalCostText;
    public TextMeshProUGUI summaryText;

    [Header("Settings")]
    public float adultPrice = 200.0f;
    public float childPrice = 100.0f;

    private int adultCount = 0;
    private int childCount = 0;

    void Start()
    {
        ticketpannel.SetActive(false);
        summaryPanel.SetActive(false);
        buttonsPanel.SetActive(true);

        Canvas canvas = ticketpannel.GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            if (canvas.GetComponent<GraphicRaycaster>() == null)
                canvas.gameObject.AddComponent<GraphicRaycaster>();

            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject es = new GameObject("EventSystem");
            es.AddComponent<EventSystem>();
            es.AddComponent<StandaloneInputModule>();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        UpdateUI();
    }

    public void OpenTicketMenu()
    {
        ticketpannel.SetActive(true);
        buttonsPanel.SetActive(true);
        summaryPanel.SetActive(false);
        ResetCounts();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void AddAdult()
    {
        adultCount++;
        UpdateUI();
    }

    public void AddChild()
    {
        childCount++;
        UpdateUI();
    }

    public void ShowSummary()
    {
        if (adultCount == 0 && childCount == 0)
        {
            Debug.LogWarning("No tickets selected!");
            return;
        }

        buttonsPanel.SetActive(false);
        summaryPanel.SetActive(true);

        float total = (adultCount * adultPrice) + (childCount * childPrice);

        string summary = "";

        if (adultCount > 0)
            summary += "Adult x" + adultCount + " = Rs." + (adultCount * adultPrice) + "\n";

        if (childCount > 0)
            summary += "Child x" + childCount + " = Rs." + (childCount * childPrice) + "\n";

        summary += "\nTotal: Rs." + total.ToString("F0");

        if (summaryText != null)
            summaryText.text = summary;
        else
            Debug.LogError("summaryText is NULL! Drag SummaryTotalText into Summary Text slot.");
    }

    public void CloseTicketMenu()
    {
        ticketpannel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        ResetCounts();
    }

    void UpdateUI()
    {
        if (adultCountText != null)
            adultCountText.text = adultCount.ToString();

        if (childCountText != null)
            childCountText.text = childCount.ToString();

        if (totalCostText != null)
        {
            float total = (adultCount * adultPrice) + (childCount * childPrice);
            totalCostText.text = "Total: Rs." + total.ToString("F0");
        }
    }

    public void ResetCounts()
    {
        adultCount = 0;
        childCount = 0;
        buttonsPanel.SetActive(true);
        summaryPanel.SetActive(false);
        UpdateUI();
    }
}