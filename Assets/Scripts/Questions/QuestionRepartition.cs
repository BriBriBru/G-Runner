using TMPro;
using UnityEngine;

public class QuestionRepartition : MonoBehaviour
{
    [SerializeField] private GameObject m_answer1;
    [SerializeField] private GameObject m_answer2;
    [SerializeField] private GameObject m_answer3;
    public TextMeshProUGUI m_questionText;

    public void FillQuestion(StepSO answer)
    {
        m_answer1.GetComponent<CubeAnswer>().FillText(answer.Responses[0]);
        m_answer2.GetComponent<CubeAnswer>().FillText(answer.Responses[1]);
        m_answer3.GetComponent<CubeAnswer>().FillText(answer.Responses[2]);

        m_questionText.text = answer.Question;
    }
}
