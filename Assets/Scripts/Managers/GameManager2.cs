using UnityEngine;
using TMPro;

public class GameManager2 : Singleton<GameManager2>
{
    private TextMeshProUGUI _textScore;
    private GameObject _gameOverUi;
    private TextMeshProUGUI _gameOverScoreText;
    private GameObject _victoryUi;
    private TextMeshProUGUI _victoryScoreText;

    public int score = 0;

    void Start()
    {
        // Score
        _textScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        
        // Game Over
        _gameOverUi = GameObject.Find("GameOver");
        _gameOverScoreText = GameObject.Find("GameOverScoreText").GetComponent<TextMeshProUGUI>();
        _gameOverUi.SetActive(false);

        // Victory
        _victoryUi = GameObject.Find("Victory");
        _victoryScoreText = GameObject.Find("VictoryScoreText").GetComponent<TextMeshProUGUI>();
        _victoryUi.SetActive(false);
    }

    public void GameOver()
    {
        // Enable game over UI
        _gameOverUi.SetActive(true);

        // Display player score
        _gameOverScoreText.text = "Score : " + score.ToString();

        // Disable player to save ressources and avoid changing score
        GameObject.Find("Player").SetActive(false);
    }

    public void Victory()
    {
        // Enable victory UI
        _victoryUi.SetActive(true);

        // Display player score
        _victoryScoreText.text = "Score : " + score.ToString();

        // Disable gameObjects for gameplay to save ressources
        GameObject.Find("QuestionManager").SetActive(false);
        GameObject.Find("Sceneries").SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void DisplayScore()
    {
        _textScore.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
}
