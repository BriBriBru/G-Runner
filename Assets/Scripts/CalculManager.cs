using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculManager : MonoBehaviour
{
    [Header("Listes")]
    [SerializeField] private List<int> m_answerList;
    public List<int> m_tuple;
    public List<List<int>> m_calculList;
    public  List<int> m_fauteList;

    [Header("Choice")]
    [SerializeField] private int m_choiceUser;

    [Header("Life")]
    //[SerializeField] GameObject m_lifeCount;

    [Header("Other Variable")]
    [SerializeField] private int m_questionNumber = 0;
    public int m_point = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_calculList = new List<List<int>>();

        LevelTwoRandom();
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

        m_tuple.Add(firstNumber);
        m_tuple.Add(secondNumber);

        Debug.Log(firstNumber);

        List<int> temp_tuple = m_tuple;

        m_calculList.Add(temp_tuple);

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

        m_tuple.Remove(0);
        m_tuple.Remove(1);

        Debug.Log(m_calculList[0][0]);
    }

    void LevelTwoRandom()
    {
        int firstNumber = Random.Range(0, 20);
        int secondNumber = Random.Range(0, 20);

        Debug.Log(firstNumber);

        m_tuple.Add(firstNumber);
        m_tuple.Add(secondNumber);

        List<int> temp_tuple = m_tuple;

        m_calculList.Add(temp_tuple);

        int answer = firstNumber * secondNumber;
        m_answerList.Add(answer);

        m_tuple.Remove(0);
        m_tuple.Remove(1);

        Debug.Log(m_calculList[0][0]);
    }

    void LevelThreeRandom()
    {
        int firstNumber = Random.Range(0, 1000);
        int secondNumber = Random.Range(0, 50);

        Debug.Log(firstNumber);

        m_tuple.Add(firstNumber);
        m_tuple.Add(secondNumber);

        List<int> temp_tuple = m_tuple;

        m_calculList.Add(temp_tuple);

        int answer = firstNumber * secondNumber;
        m_answerList.Add(answer);

        m_tuple.Remove(0);
        m_tuple.Remove(1);

        Debug.Log(m_calculList[0][0]);
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
