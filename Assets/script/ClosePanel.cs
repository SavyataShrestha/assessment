using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject infoPanel;

    public void Close()
    {
        infoPanel.SetActive(false);
    }
}