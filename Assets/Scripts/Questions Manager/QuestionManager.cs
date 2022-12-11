using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor;

public class QuestionManager : MonoBehaviour
{
    private StepSO m_data;
    [SerializeField] private GameObject m_question;
    [SerializeField] private TextMeshProUGUI m_textForQuestion;
    [SerializeField] private List<int> m_listEasy;
    [SerializeField] private List<int> m_listMedium;
    [SerializeField] private List<int> m_listHard;

    // Start is called before the first frame update
    void Start()
    {
        FillListOfQuestion();

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
            int tempInt = Random.Range(1, m_listEasy.Count);

            m_data = Resources.Load("ScriptablesObjects/Easy/StepEasy" + tempInt.ToString()) as StepSO;

            m_listEasy.Remove(tempInt);
        }
        else if (difficulty == Difficulty.medium)
        {
            int tempInt = Random.Range(1, m_listMedium.Count);

            m_data = Resources.Load("ScriptablesObjects/Medium/StepMedium" + tempInt.ToString()) as StepSO;

            m_listMedium.Remove(tempInt);
        }
        else if (difficulty == Difficulty.hard)
        {
            int tempInt = Random.Range(1, m_listHard.Count);

            m_data = Resources.Load("ScriptablesObjects/Hard/StepHard" + tempInt.ToString()) as StepSO;

            m_listHard.Remove(tempInt);
        }

        GameObject newQuestion = Instantiate(m_question);

        newQuestion.GetComponent<QuestoinRepartition>().m_questionText = m_textForQuestion;

        newQuestion.GetComponent<QuestoinRepartition>().FillQuestion(m_data);
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
