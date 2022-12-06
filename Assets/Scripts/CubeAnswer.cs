using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeAnswer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private bool m_isCorect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillText(Response response)
    {
        text.text = response.responseString;
        m_isCorect = response.isCorrect;
    }
}
