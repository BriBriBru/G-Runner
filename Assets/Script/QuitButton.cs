using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{

    [Header("Button")]
    [SerializeField] private Button m_quitButton;

    // Start is called before the first frame update
    void Start()
    {
        m_quitButton.onClick.AddListener(QuitApp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
