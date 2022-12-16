using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{    
    private Button m_startButton;

    void Start()
    {
        m_startButton = GetComponent<Button>();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Runner");
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
