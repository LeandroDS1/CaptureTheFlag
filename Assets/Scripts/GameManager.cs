using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform playerBase;
    public Transform aiBase;
    public GameObject playerFlagPrefab;
    public GameObject aiFlagPrefab;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;
    public TextMeshProUGUI winnerText;
    public int maxScore = 5;

    private int playerScore = 0;
    private int aiScore = 0;
    private bool gameActive = false;
    private bool roundEnded = false;

    private GameObject playerFlagInstance;
    private GameObject aiFlagInstance;

    private void Start()
    {
        ResetRound();
    }

    private void Update()
    {
        playerScoreText.text = "Player: " + playerScore;
        aiScoreText.text = "AI: " + aiScore;

        if (!roundEnded)
        {
            if (playerScore >= maxScore)
            {
                winnerText.text = "Player wins!";
                EndRound();
            }
            else if (aiScore >= maxScore)
            {
                winnerText.text = "AI wins!";
                EndRound();
            }
        }
    }

    public void PlayerScored()
    {
        if (!roundEnded)
        {
            playerScore++;
            if (playerScore >= maxScore)
            {
                winnerText.text = "Player wins!";
                EndRound();
            }
        }
    }

    public void AIScored()
    {
        if (!roundEnded)
        {
            aiScore++;
            if (aiScore >= maxScore)
            {
                winnerText.text = "AI wins!";
                EndRound();
            }
        }
    }

    public bool IsGameActive()
    {
        return gameActive;
    }

    public void StartGame()
    {
        gameActive = true;


        playerFlagInstance = Instantiate(playerFlagPrefab, playerBase.position, Quaternion.identity);
        playerFlagInstance.SetActive(true);

        aiFlagInstance = Instantiate(aiFlagPrefab, aiBase.position, Quaternion.identity);
        aiFlagInstance.SetActive(true);
    }

    public void EndGame()
    {
        gameActive = false;

        Destroy(playerFlagInstance);
        Destroy(aiFlagInstance);
    }

    private void ResetRound()
    {
        EndGame();

        winnerText.text = "";
        playerScore = 0;
        aiScore = 0;
        roundEnded = false;
    }

    private void EndRound()
    {
        roundEnded = true;
    }
}