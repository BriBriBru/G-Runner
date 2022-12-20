using UnityEngine;
using TMPro;

public class PlayerChooseAnswer : MonoBehaviour
{
    [SerializeField] private QuestionManager m_questionManager;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private GameObject _gameOverUi;

    private TextMeshProUGUI _gameOverScoreText;
    private int m_score = 0;

    public bool m_alive = true;

    void Start()
    {
        _gameOverUi.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Answer")
        {
            if(other.GetComponent<CubeAnswer>().m_isCorect == true)
            {
                m_score += 1;
                m_scoreText.text = m_score.ToString();
            }
            
            else
            {
                _gameOverScoreText = _gameOverUi.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
                _gameOverScoreText.text = "Score : " + m_score.ToString();
                _gameOverUi.SetActive(true);
                m_questionManager.gameObject.SetActive(false);
            }

            Destroy(other.transform.parent.gameObject);
            m_questionManager.FillQuestion(Difficulty.easy);
        }
    }
}