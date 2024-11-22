using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DiceGameManager : MonoBehaviour
{
    public GameObject dicePanel; // Panel for dice selection
    public GameObject winPanel;  // Panel for game won
    public GameObject losePanel; // Panel for game lost

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI enemyScoreText;
    public TextMeshProUGUI winPlayerStats;
    public TextMeshProUGUI winEnemyStats;
    public TextMeshProUGUI losePlayerStats;
    public TextMeshProUGUI loseEnemyStats;

    public List<Button> diceButtons; // Buttons for dice (12, 24, 36, 48)

    private int playerScore = 0;
    private int enemyScore = 0;

    private List<int> diceValues = new List<int> { 12, 24, 36, 48 };
    private int round = 0;

    void Start()
    {
        // Set up button listeners for dice selection
        for (int i = 0; i < diceButtons.Count; i++)
        {
            int diceValue = diceValues[i];
            diceButtons[i].onClick.AddListener(() => PlayerRollDice(diceValue));
        }
    }

    public void StartDiceGame()
    {
        round = 0;
        playerScore = 0;
        enemyScore = 0;

        diceValues = new List<int> { 12, 24, 36, 48 }; // Reset dice
        foreach (Button btn in diceButtons)
            btn.gameObject.SetActive(true); // Reactivate all dice

        dicePanel.SetActive(true); // Show the dice panel
    }

    void PlayerRollDice(int diceValue)
    {
        int roll = Random.Range(1, diceValue + 1);
        playerScore += roll;
        Debug.Log($"Player rolled {roll} on a d{diceValue}!");

        // Remove used dice
        diceValues.Remove(diceValue);
        RemoveDiceButton(diceValue);

        // Enemy's turn
        EnemyRollDice();
    }

    void EnemyRollDice()
    {
        if (diceValues.Count == 0)
        {
            EndGame();
            return;
        }

        // Randomly select a dice for the enemy
        int randomIndex = Random.Range(0, diceValues.Count);
        int diceValue = diceValues[randomIndex];
        int roll = Random.Range(1, diceValue + 1);
        enemyScore += roll;
        Debug.Log($"Enemy rolled {roll} on a d{diceValue}!");

        // Remove used dice
        diceValues.RemoveAt(randomIndex);
        RemoveDiceButton(diceValue);

        round++;
        if (round >= 4)
        {
            EndGame();
        }
    }

    void RemoveDiceButton(int diceValue)
    {
        foreach (Button btn in diceButtons)
        {
            if (btn.GetComponentInChildren<TextMeshProUGUI>().text == diceValue.ToString())
            {
                btn.gameObject.SetActive(false); // Hide the button
                break;
            }
        }
    }

    void EndGame()
    {
        dicePanel.SetActive(false);

        if (playerScore > enemyScore)
        {
            // Show win panel
            winPanel.SetActive(true);
            winPlayerStats.text = $"Player Score: {playerScore}";
            winEnemyStats.text = $"Enemy Score: {enemyScore}";
        }
        else
        {
            // Show lose panel
            losePanel.SetActive(true);
            losePlayerStats.text = $"Player Score: {playerScore}";
            loseEnemyStats.text = $"Enemy Score: {enemyScore}";
        }
    }

    public void OnWinOkButton()
    {
        winPanel.SetActive(false);
        Debug.Log("Player resumes movement.");
        // Add logic to resume gameplay here
    }

    public void OnLosePlayAgainButton()
    {
        losePanel.SetActive(false);
        StartDiceGame();
    }

    public void OnLoseQuitButton()
    {
        Debug.Log("Quit to main menu.");
        // Add logic for quitting to main menu
    }
}