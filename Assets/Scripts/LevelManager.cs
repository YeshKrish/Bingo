using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [HideInInspector]
    public string player1Text;
    [HideInInspector]
    public string player2Text;

    public Button StartGameButton;

    private void Awake()
    {
        player1Text = "Player1";
        player2Text = "Player2";
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
   
    public void LevelChange()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void AssignPlayer1Name(string name)
    {
        player1Text = name;
        Debug.Log(player1Text);
    }
    public void AssignPlayer2Name(string name)
    {
        player2Text = name;
        Debug.Log(player2Text);
    }
}
