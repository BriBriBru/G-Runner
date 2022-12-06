using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestoinRepartition : MonoBehaviour
{
    [SerializeField] private GameObject m_answer1;
    [SerializeField] private GameObject m_answer2;
    [SerializeField] private GameObject m_answer3;
    public TextMeshProUGUI m_questionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillQuestion(StepSO answer)
    {
        m_answer1.GetComponent<CubeAnswer>().FillText(answer.Responses[0]);
        m_answer2.GetComponent<CubeAnswer>().FillText(answer.Responses[1]);
        m_answer3.GetComponent<CubeAnswer>().FillText(answer.Responses[2]);

        m_questionText.text = answer.Question;
    }
}
