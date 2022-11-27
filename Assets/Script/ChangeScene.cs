using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    [Header("Button")]
    [SerializeField] private Button m_startButton;

    [Header("Name Scene")]
    [SerializeField] private string m_sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        m_startButton.onClick.AddListener(GoToGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToGame()
    {
        SceneManager.LoadScene(m_sceneToLoad);
    }
}
