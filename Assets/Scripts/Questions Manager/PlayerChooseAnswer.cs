using UnityEngine;
using TMPro;

public class PlayerChooseAnswer : MonoBehaviour
{
    [SerializeField] private QuestionManager m_questionManager;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private GameObject m_finishCanvas;
    [SerializeField] private TextMeshProUGUI m_finishText;

    public bool m_alive = true;

    private int m_score = 0;

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
                m_alive = false;
            }

            Destroy(other.transform.parent.gameObject);

            m_questionManager.FillQuestion(Difficulty.easy);
        }
    }
}