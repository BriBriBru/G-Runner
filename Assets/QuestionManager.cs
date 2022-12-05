using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    private StepSO m_data;
    [SerializeField] private GameObject m_question;
    [SerializeField] private TextMeshProUGUI m_textForQuestion; 

    // Start is called before the first frame update
    void Start()
    {
        FillQuestion(Difficulty.easy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillQuestion(Difficulty difficulty)
    {
        if(difficulty == Difficulty.easy)
        {
            m_data = Resources.Load("ScriptablesObjects/Easy/StepEasy" + 1.ToString()) as StepSO;
        }
        else if (difficulty == Difficulty.medium)
        {
            m_data = Resources.Load("ScriptablesObjects/Medium/StepMedium" + 1.ToString()) as StepSO;
        }
        else if (difficulty == Difficulty.hard)
        {
            m_data = Resources.Load("ScriptablesObjects/Hard/StepHard" + 1.ToString()) as StepSO;
        }

        GameObject newQuestion = Instantiate(m_question);

        newQuestion.GetComponent<QuestoinRepartition>().m_questionText = m_textForQuestion;

        newQuestion.GetComponent<QuestoinRepartition>().FillQuestion(m_data);
    }
}
