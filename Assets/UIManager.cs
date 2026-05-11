using UnityEngine;
using TMPro;

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
        infoText.text = "The game is related to our historical places. in this game, the players are able to move our the surroundings and explore the places like ranipokhari, dharara, ghataghar and tudikhel . they can also find the information about the places attach near the place. the player can also purchase tickets to go to dharara.";
    }
     public void HideDescription()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}