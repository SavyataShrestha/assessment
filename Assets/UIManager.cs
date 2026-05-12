using TMPro;
using Unity.Burst.Intrinsics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject infoPanel;
    public TMP_Text infoText;

    void Start()
    {
        infoPanel.SetActive(false);
    }

    public void ShowDescription()
    {
        infoPanel.SetActive(true);
        infoText.text = "The game is related to our historical places.In this game, the players are able to move around the surroundings and explore the places like Ranipokhari, Dharara, Ghataghar and Tudikhel.They can also find information about the places attached near each location. The player can also purchase tickets to visit Dharara." ;
    }
     public void HideDescription()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}