using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Player> AllPlayer;

    public void ButtonClicked(Button button)
    {
        foreach (Player player in AllPlayer)
        {
            player.ClickButton(button.name);
        }    
    } 

}
