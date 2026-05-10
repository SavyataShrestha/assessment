using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
        UpdateUI();
    }

    // Call this when player walks up to ticket booth
    public void OpenTicketMenu()
    {
        ticketpannel.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // unlock cursor
        Cursor.visible = true;                  // show cursor
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
        buttonsPanel.SetActive(false);
        summaryPanel.SetActive(true);
    }

    public void CloseTicketMenu()
    {
        ticketpannel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // lock cursor again
        Cursor.visible = false;                    // hide cursor
        ResetCounts();
    }

    void UpdateUI()
    {
        if (adultCountText != null) adultCountText.text = adultCount.ToString();
        if (childCountText != null) childCountText.text = childCount.ToString();
        if (totalCostText != null)
        {
            float total = (adultCount * adultPrice) + (childCount * childPrice);
            totalCostText.text = "Total: Rs " + total.ToString("F0");
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