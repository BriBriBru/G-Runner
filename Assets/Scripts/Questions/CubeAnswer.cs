using TMPro;
using UnityEngine;

public class CubeAnswer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public bool m_isCorect;

    public void FillText(Response response)
    {
        text.text = response.responseString;
        m_isCorect = response.isCorrect;
    }
}
