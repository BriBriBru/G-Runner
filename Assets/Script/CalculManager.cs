using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculManager : MonoBehaviour
{
    [Header("Listes")]
    [SerializeField] private List<List<int>> m_calculList;
    [SerializeField] private List<int> m_answerList;
    private List<int> tupleNumber;
    private List<int> m_fauteList;

    [Header("Choice")]
    [SerializeField] private int m_choiceUser;

    [Header("Life")]
    [SerializeField] GameObject m_lifeCount;

    [Header("Other Variable")]
    [SerializeField] private int m_questionNumber = 0;
    private int m_point = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculGenerator()
    {

    }

    void LevelOneRandom()
    {
        int firstNumber = Random.Range(0,10);
        int secondNumber = Random.Range(0, 10);

        tupleNumber.Add(firstNumber);
        tupleNumber.Add(secondNumber);

        m_calculList.Add(tupleNumber);
        tupleNumber.Clear();

        int sign = Random.Range(0, 1);

        if(sign == 0)
        {
            int answer = firstNumber + secondNumber;
            m_answerList.Add(answer);
        }
        else if(sign == 1)
        {
            int answer = firstNumber - secondNumber;
            m_answerList.Add(answer);
        }
    }


    void CheckAnswer()
    {
        if(m_choiceUser == m_answerList[m_questionNumber])
        {
            m_point += 1;
        }
        else if(m_choiceUser != m_answerList[m_questionNumber])
        {
            m_fauteList.Add(m_questionNumber);
        }
    }
}
