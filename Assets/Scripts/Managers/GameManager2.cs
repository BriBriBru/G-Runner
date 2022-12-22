using UnityEngine;
using TMPro;

public class GameManager2 : Singleton<GameManager2>
{
    private TextMeshProUGUI _textScore;
    private GameObject _gameOverUi;
    private TextMeshProUGUI _gameOverScoreText;

    public int score = 0;

    void Start()
    {
        _textScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        _gameOverUi = GameObject.Find("GameOver");
        _gameOverScoreText = GameObject.Find("GameOverScoreText").GetComponent<TextMeshProUGUI>();
        _gameOverUi.SetActive(false);
    }

    public void GameOver()
    {
        // Enable Game Over UI
        _gameOverUi.SetActive(true);

        // Display player score
        _gameOverScoreText.text = "Score : " + score.ToString();

        // Disable gameObjects for gameplay to save ressources
        GameObject.Find("QuestionManager").SetActive(false);
        GameObject.Find("Sceneries").SetActive(false);

        // Reset Score
        score = 0;
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void DisplayScore()
    {
        _textScore.text = score.ToString();
    }
}
