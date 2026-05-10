using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private TicketSystemManager ticketSystem;

    void Start()
    {
        ticketSystem = FindFirstObjectByType<TicketSystemManager>();
    }

    public void OnExitClick()
    {
        ticketSystem.CloseTicketMenu();
    }
}