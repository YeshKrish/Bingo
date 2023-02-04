using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject PlayeWinPanel;
    public List<Button> AllButtons;
    public List<Button> BINGOButtons;
    public AudioSource winClip;
    public TMP_Text Player1Name;
    public TMP_Text Player2Name;   
    public TMP_Text Winner1Name;
    public TMP_Text Winner2Name;

    private List<Button> rowButtons;
    private List<Button> columnButtons;

    int _BINGOIndex;

    bool _currentRowCompleted;
    bool _currentColumnCompleted;

    private void Awake()
    {
        Player1Name.text = LevelManager.instance.player1Text;
        Player2Name.text = LevelManager.instance.player2Text;
        Winner1Name.text = "Hurray!" + LevelManager.instance.player1Text + "Won The Game";
        Winner2Name.text = "Hurray!" + LevelManager.instance.player2Text + "Won The Game";
    }

    private void Start()
    {
        RandomizeValue();
        rowButtons = AllButtons;
        columnButtons = new List<Button>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < AllButtons.Count; j += 5)
            {
                columnButtons.Add(AllButtons[i + j]);
            }
        }
    }

    void RandomizeValue()
    {
        List<int> numbers = new List<int>();
        for(int i = 1; i < 26; i++)
        {
            numbers.Add(i);
        }
        System.Random rand = new System.Random();
        for (int i = numbers.Count - 1; i > 0; i--)
        {
            int k = rand.Next(i + 1);
            int value = numbers[k];
            numbers[k] = numbers[i];
            numbers[i] = value;
        }
        for (int i = 0; i < AllButtons.Count; i++)
        {
            AllButtons[i].name = numbers[i].ToString();
            AllButtons[i].GetComponentInChildren<TMP_Text>().text = numbers[i].ToString();

        }
    }

    public void ClickButton(string buttonName)
    {
        Button button = AllButtons[0];
        foreach (Button i in AllButtons)
        {
            if(i.name == buttonName)
            {
                button = i;
                break;
            }
        }
        button.interactable = false;
        button.GetComponent<Image>().color = Color.cyan;

        CheckRowComplete();
        CheckColumnComplete();
        CheckForWin();
    }

    void StrikeBINGO()
    {
        _BINGOIndex++;
        for (int i = 0; i < _BINGOIndex; i++)
        {
            BINGOButtons[i].image.color = Color.red;
        }

    }

    void CheckForWin()
    {
        if (_BINGOIndex == 5)
        {
            winClip.Play();
            PlayeWinPanel.SetActive(true);
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }

    void CheckRowComplete()
    {
        for (int i = 0; i < rowButtons.Count; i += 5)
        {
            _currentRowCompleted = true;
            for (int j = 0; j < 5; j++)
            {
                if (rowButtons[i + j].interactable)
                {
                    _currentRowCompleted = false;
                }

            }
            if (_currentRowCompleted == true)
            {
                RemoveRow(i);
                StrikeBINGO();
            }
        }
    }

    void RemoveRow(int remove)
    {
        List<Button> _buttonRemove = new List<Button>();
        for (int i = remove; i < remove + 5; i++)
        {
            _buttonRemove.Add(AllButtons[i]);
        }
        for (int i = 0; i < _buttonRemove.Count; i++)
        {
            rowButtons.Remove(_buttonRemove[i]);

        }
    }

    void CheckColumnComplete()
    {
        for (int i = 0; i < columnButtons.Count; i += 5)
        {
            _currentColumnCompleted = true;
            for (int j = 0; j < 5; j++)
            {
                if (columnButtons[i + j].interactable)
                {
                    _currentColumnCompleted = false;
                }
            }
            if (_currentColumnCompleted == true)
            {
                RemoveColumn(i);
                StrikeBINGO();
            }
        }
    }
    void RemoveColumn(int remove)
    {
        List<Button> _buttonRemove = new List<Button>();
        for (int i = remove; i < remove + 5; i++)
        {
            _buttonRemove.Add(columnButtons[i]);
        }
        for (int i = 0; i < _buttonRemove.Count; i++)
        {
            columnButtons.Remove(_buttonRemove[i]);

        }
    }
}
