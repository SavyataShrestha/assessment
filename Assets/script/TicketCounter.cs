using UnityEngine;
using TMPro;

public class TicketCounter : MonoBehaviour
{
    public GameObject ticketPanel;
    public TextMeshProUGUI pressEText;
    private int playerCount = 0;
    private bool panelOpen = false;
    private TicketSystemManager ticketSystem;

    void Start()
    {
        ticketPanel.SetActive(false);
        pressEText.gameObject.SetActive(false);
        ticketSystem = FindObjectOfType<TicketSystemManager>();
        if (ticketSystem == null)
            Debug.LogError("TicketSystemManager not found in scene!");
    }

    void Update()
    {
        if (playerCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            panelOpen = !panelOpen;
            ticketPanel.SetActive(panelOpen);

            if (panelOpen)
            {
                pressEText.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;  // unlock cursor
                Cursor.visible = true;                    // show cursor
                if (ticketSystem != null)
                    ticketSystem.ResetCounts();
            }
            else
            {
                pressEText.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked; // lock cursor
                Cursor.visible = false;                    // hide cursor
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount++;
            if (!panelOpen)
            {
                pressEText.text = "Press E to purchase ticket";
                pressEText.gameObject.SetActive(true);
            }
            Debug.Log("Player entered zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCount--;
            if (playerCount <= 0)
            {
                playerCount = 0;
                panelOpen = false;
                ticketPanel.SetActive(false);
                pressEText.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked; // lock cursor on exit
                Cursor.visible = false;                    // hide cursor on exit
                if (ticketSystem != null)
                    ticketSystem.ResetCounts();
                Debug.Log("Player left zone");
            }
        }
    }
}