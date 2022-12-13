using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerChooseAnswer : MonoBehaviour
{
    [SerializeField] private QuestionManager m_questionManager;
    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private GameObject m_life;
    [SerializeField] private GameObject m_finishCanvas;
    [SerializeField] private TextMeshProUGUI m_finishText;

    private int m_score = 0;
    private int m_fail = 0;

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
                m_fail += 1;

                if(m_fail == 1)
                {
                    m_life.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(0,0,0, 50);
                }
                else if (m_fail == 2)
                {
                    m_life.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 50);
                }
                else
                {
                    m_life.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 50);
                    m_finishCanvas.SetActive(true);
                    m_finishText.text = "You loose all your lives";
                }
            }

            Destroy(other.transform.parent.gameObject);

            m_questionManager.FillQuestion(Difficulty.easy);
        }
    }
}