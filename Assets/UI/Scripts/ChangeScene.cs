using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{    
    public void GoToGame()
    {
        SceneManager.LoadScene("Runner");
        GameManager2.Instance.ResetScore();
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
        GameManager2.Instance.ResetScore();
    }
}
