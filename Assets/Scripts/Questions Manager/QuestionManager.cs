using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    private StepSO m_data;
    [SerializeField] private GameObject m_question;
    [SerializeField] private TextMeshProUGUI m_textForQuestion;
    [SerializeField] private List<int> m_listEasy;
    [SerializeField] private List<int> m_listMedium;
    [SerializeField] private List<int> m_listHard;
    [SerializeField] private GameObject m_finishCanvas;
    [SerializeField] private TextMeshProUGUI m_finishText;
    [SerializeField] private PlayerChooseAnswer m_player;

    void Start()
    {
        FillListOfQuestion();

        FillQuestion(Difficulty.easy);
    }

    public void FillQuestion(Difficulty difficulty)
    {
        if(m_player.m_alive != false)
        {
            if (difficulty == Difficulty.easy)
            {
                if (m_listEasy.Count != 0)
                {
                    int tempInt = Random.Range(1, m_listEasy.Count);

                    m_data = Resources.Load("ScriptablesObjects/Easy/StepEasy" + tempInt.ToString()) as StepSO;

                    m_listEasy.Remove(tempInt);

                    GameObject newQuestion = Instantiate(m_question);

                    newQuestion.GetComponent<QuestoinRepartition>().m_questionText = m_textForQuestion;

                    newQuestion.GetComponent<QuestoinRepartition>().FillQuestion(m_data);
                }
                else
                {
                    difficulty = Difficulty.medium;
                }
            }

            if (difficulty == Difficulty.medium)
            {
                if (m_listMedium.Count != 0)
                {
                    int tempInt = Random.Range(1, m_listMedium.Count);

                    m_data = Resources.Load("ScriptablesObjects/Medium/StepMedium" + tempInt.ToString()) as StepSO;

                    m_listMedium.Remove(tempInt);

                    GameObject newQuestion = Instantiate(m_question);

                    newQuestion.GetComponent<QuestoinRepartition>().m_questionText = m_textForQuestion;

                    newQuestion.GetComponent<QuestoinRepartition>().FillQuestion(m_data);
                }
                else
                {
                    difficulty = Difficulty.hard;
                }
            }

            if (difficulty == Difficulty.hard)
            {
                if (m_listHard.Count != 0)
                {
                    int tempInt = Random.Range(1, m_listHard.Count);

                    m_data = Resources.Load("ScriptablesObjects/Hard/StepHard" + tempInt.ToString()) as StepSO;

                    m_listHard.Remove(tempInt);

                    GameObject newQuestion = Instantiate(m_question);

                    newQuestion.GetComponent<QuestoinRepartition>().m_questionText = m_textForQuestion;

                    newQuestion.GetComponent<QuestoinRepartition>().FillQuestion(m_data);
                }
                else
                {
                    m_finishCanvas.SetActive(true);
                    m_finishText.text = "You succeed all the question";
                    
                }
            }
        }
    }

    public void FillListOfQuestion()
    {
        for (int i = 0; i < 10/*Directory.GetFiles(Application.dataPath + "/Resources/ScriptablesObjects/Easy", "*.asset").Length*/; i++)
        {
            m_listEasy.Add(i);
        }

        for (int i = 0; i < 10/*Directory.GetFiles(Application.dataPath + "/Resources/ScriptablesObjects/Medium", "*.asset").Length*/; i++)
        {
            m_listMedium.Add(i);
        }

        for (int i = 0; i < 10/*Directory.GetFiles(Application.dataPath + "/Resources/ScriptablesObjects/Hard", "*.asset").Length*/; i++)
        {
            m_listHard.Add(i);
        }
    }
}
