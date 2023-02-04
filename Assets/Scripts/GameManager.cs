using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<Player> AllPlayer;

    public int currentTurn = 1;

    public GameObject player1Button;
    public GameObject player2Button;

    private void Start()
    {
        player1Button.GetComponentInChildren<TMP_Text>().text = LevelManager.instance.player1Text +"'s Turn";
        player2Button.GetComponentInChildren<TMP_Text>().text = LevelManager.instance.player2Text +"'s Turn";
        player1Button.SetActive(true);
        player2Button.SetActive(false);
    }

    public void ButtonClicked(Button button)
    {
        TakeTurn(button.transform.parent.name);
        Debug.Log("Button Cliked" + button.transform.parent.name);
        foreach (Player player in AllPlayer)
        {
            player.ClickButton(button.name);
        }    
    } 

    void TakeTurn(string parentName)
    {
        if(parentName == "Player1")
        {
            player1Button.SetActive(false);
            player2Button.SetActive(true);
        }
        else if(parentName == "Player2")
        {
            player1Button.SetActive(true);
            player2Button.SetActive(false);
        }
    }

}
