using UnityEngine;
using TMPro;

public class PlayerChooseAnswer : MonoBehaviour
{
    [SerializeField] private QuestionManager m_questionManager;

    private TextMeshProUGUI _gameOverScoreText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Answer")
        {
            // Player answer is correct
            if(other.GetComponent<CubeAnswer>().m_isCorect == true)
            {
                GameManager2.Instance.IncreaseScore();
                GameManager2.Instance.DisplayScore();
            }
            
            // Player answer is incorrect
            else
            {
                GameManager2.Instance.GameOver();
            }

            Destroy(other.transform.parent.gameObject);
            m_questionManager.FillQuestion(Difficulty.easy);
        }
    }
}